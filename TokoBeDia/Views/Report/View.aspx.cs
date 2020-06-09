using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handler;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Report
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region check session & set navbar
            var userSession = Session["user"];

            if (userSession != null)
            {
                // if user Logged on
                var userId = int.Parse(userSession.ToString());
                var user = UserRepository.findById(userId);

                if (user.RoleId == 1)
                {
                    // Admin
                    #region set admin navbar visible
                    homeNavbar.Visible = true;

                    profileNavbar.Visible = true;
                    profile_view.Visible = true;
                    profile_changeprof.Visible = true;
                    profile_changepass.Visible = true;

                    usersNavbar.Visible = true;
                    user_view.Visible = true;

                    productsNavbar.Visible = true;
                    product_view.Visible = true;
                    product_insert.Visible = true;

                    productTypesNavbar.Visible = true;
                    ptype_view.Visible = true;
                    ptype_insert.Visible = true;

                    loginNavbar.Visible = false;
                    registerNavbar.Visible = false;
                    logoutNavbar.Visible = true;

                    paymentTypesNavbar.Visible = true;
                    paymenttype_view.Visible = true;
                    paymenttype_insert.Visible = true;
                    #endregion set navbar visible

                    CrystalReport();
                }
                else if (user.RoleId == 2)
                {
                    // Member
                    Response.Redirect("../Home.aspx");
                }

            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
            #endregion check session & set navbar
        }

        private void CrystalReport()
        {
            TransactionReport transactionReport = new TransactionReport();
            CrystalReportViewer.ReportSource = transactionReport;

            transactionReport.SetDataSource( GenerateData( HeaderTransactionRepository.findAll() ) );
        }

        private DataSet GenerateData(List<HeaderTransaction> transactionList)
        {
            DataSet newDataSet = new DataSet();
            var headerTransactionTable = newDataSet.HeaderTransaction;
            var detailTransactionTable = newDataSet.DetailTransaction;

            foreach (var ht in transactionList)
            {
                var headerTransactionRow = headerTransactionTable.NewRow();
                headerTransactionRow["Id"] = ht.Id;
                headerTransactionRow["UserName"] = ht.User.Name;
                headerTransactionRow["PaymentTypeName"] = ht.PaymentType.Type;
                headerTransactionRow["Date"] = ht.Date ?? DateTime.Now;

                headerTransactionTable.Rows.Add(headerTransactionRow);

                var detailTransactions = DetailTransactionRepository.findAllByTransactionId(ht.Id);
                foreach (var dt in detailTransactions)
                {
                    var detailTransactionRow = detailTransactionTable.NewRow();
                    detailTransactionRow["TransactionId"] = dt.TransactionId;
                    detailTransactionRow["ProductName"] = dt.Product.Name;
                    detailTransactionRow["ProductPrice"] = dt.Product.Price;
                    detailTransactionRow["Quantity"] = dt.Quantity;

                    detailTransactionTable.Rows.Add(detailTransactionRow);
                }
            }

            return newDataSet;
        }
    }
}