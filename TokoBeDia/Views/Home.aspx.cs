using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userSession = Session["user"];

            if(userSession != null)
            {
                // if user Logged on
                var userId = int.Parse(userSession.ToString());
                var user = UserRepository.findById(userId);

                role.InnerText = user.Role.Name;
                notificationcontainer.Text = "";

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

                    //remind set to false
                    cartNavbar.Visible = true;
                    cart_view.Visible = true;
                    cart_insert.Visible = true;

                    btnTransactionReport.Visible = true;
                    btnTransactionHistoryAdmin.Visible = true;
                    btnTransactionHistoryMember.Visible = false;
                    #endregion set navbar visible
                    gv_ViewProductAdmin.Visible = true;
                    gv_ViewProductPublic.Visible = false;
                }
                else if (user.RoleId == 2)
                {
                    // Member
                    #region set member navbar visible
                    homeNavbar.Visible = true;

                    profileNavbar.Visible = true;
                    profile_view.Visible = true;
                    profile_changeprof.Visible = true;
                    profile_changepass.Visible = true;

                    usersNavbar.Visible = false;
                    user_view.Visible = false;

                    productsNavbar.Visible = true;
                    product_view.Visible = true;
                    product_insert.Visible = false;

                    productTypesNavbar.Visible = false;
                    ptype_view.Visible = false;
                    ptype_insert.Visible = false;

                    loginNavbar.Visible = false;
                    registerNavbar.Visible = false;
                    logoutNavbar.Visible = true;

                    paymentTypesNavbar.Visible = false;
                    paymenttype_view.Visible = false;
                    paymenttype_insert.Visible = false;

                    cartNavbar.Visible = true;
                    cart_view.Visible = true;
                    cart_insert.Visible = true;

                    btnTransactionReport.Visible = false;
                    btnTransactionHistoryAdmin.Visible = false;
                    btnTransactionHistoryMember.Visible = true;
                    #endregion set navbar visible
                    gv_ViewProductAdmin.Visible = false;
                    gv_ViewProductPublic.Visible = true;
                }


            }
            else
            {
                // If user not logged on

                #region set navbar visible
                homeNavbar.Visible = true;

                profileNavbar.Visible = false;
                profile_view.Visible = false;
                profile_changeprof.Visible = false;
                profile_changepass.Visible = false;

                usersNavbar.Visible = false;
                user_view.Visible = false;

                productsNavbar.Visible = true;
                product_view.Visible = true;
                product_insert.Visible = false;

                productTypesNavbar.Visible = false;
                ptype_view.Visible = false;
                ptype_insert.Visible = false;

                loginNavbar.Visible = true;
                registerNavbar.Visible = true;
                logoutNavbar.Visible = false;

                paymentTypesNavbar.Visible = false;
                paymenttype_view.Visible = false;
                paymenttype_insert.Visible = false;

                cartNavbar.Visible = false;
                cart_view.Visible = false;
                cart_insert.Visible = false;

                btnTransactionReport.Visible = false;
                btnTransactionHistoryAdmin.Visible = false;
                btnTransactionHistoryMember.Visible = false;
                #endregion set navbar visible
                role.InnerText = "Guest";
                notificationcontainer.Text = "Please Login first";

                gv_ViewProductAdmin.Visible = false;
                gv_ViewProductPublic.Visible = true;
            }

            refreshTable();
        }

        private void refreshTable()
        {
            gv_ViewProductAdmin.DataSource = ProductRepository.findTopFive();
            gv_ViewProductAdmin.DataBind();

            gv_ViewProductPublic.DataSource = ProductRepository.findTopFive();
            gv_ViewProductPublic.DataBind();
        }

        protected void btnTransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report/View.aspx");
        }

        protected void btnTransactionHistoryAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory/Admin.aspx");
        }

        protected void btnTransactionHistoryMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionHistory/Member.aspx");

        }
    }
}