using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handler;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.TransactionHistory
{
    public partial class Member : System.Web.UI.Page
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
                    Response.Redirect("../Home.aspx");

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
                    #endregion set navbar visible
                    refreshGridView();
                }

            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
            #endregion check session & set navbar
        }

        private void refreshGridView()
        {
            gv_MemberTransactionHistory.DataSource = TransactionHandler.findByUserId( int.Parse(Session["user"].ToString()) );
            gv_MemberTransactionHistory.DataBind();

            var getTransactionStats = TransactionHandler.getTotalTransactionMember(int.Parse(Session["user"].ToString()) );
            dynamic stats = getTransactionStats;

            totalQuantity.Text = ((int)stats.TotalQuantity).ToString();
            grandTotal.Text = ((int)stats.TotalPrice).ToString();
        }

        protected void gv_MemberTransactionHistory_PreRender(object sender, EventArgs e)
        {
            Class.Global.GridViewMergeRows(gv_MemberTransactionHistory);
        }
    }
}