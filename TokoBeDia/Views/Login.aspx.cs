using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBeDia.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userSession = Session["user"];

            if (userSession != null)
            {
                // if user Logged on
                var userId = int.Parse(userSession.ToString());
                Response.Redirect("Home.aspx");
            }
            else
            {
                // If user not logged on

                // initialize navbar
                #region set navbar visible
                homeNavbar.Visible = true;

                profileNavbar.Visible = false;
                profile_view.Visible = false;
                profile_changeprof.Visible = false;
                profile_changepass.Visible = false;

                usersNavbar.Visible = false;
                user_view.Visible = false;
                user_insert.Visible = false;

                productsNavbar.Visible = true;
                product_view.Visible = true;
                product_insert.Visible = false;

                productTypesNavbar.Visible = false;
                ptype_view.Visible = false;
                ptype_insert.Visible = false;

                loginNavbar.Visible = true;
                registerNavbar.Visible = true;
                logoutNavbar.Visible = false;
                #endregion set navbar visible

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var email = inputEmail.Text;
            var password = inputPassword.Text;
        }
    }
}