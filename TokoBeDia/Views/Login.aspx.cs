using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Class;
using TokoBeDia.Repository;

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
                #endregion set navbar visible

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loginHelp.Visible = false;

            var email = inputEmail.Text;
            var password = inputPassword.Text;
            var rememberMe = cboxRememberMe.Checked;

            if (email.Length <= 0)
            {
                loginHelp.Text = "Email cannot be empty";
                loginHelp.Visible = true;
                return;
            }

            if (password.Length <= 0)
            {
                loginHelp.Text = "Password cannot be empty";
                loginHelp.Visible = true;
                return;
            }

            var user = UserRepository.findByEmail(email, password);
            if(user == null)
            {
                loginHelp.Text = "Credentials not found";
                loginHelp.Visible = true;
                return;
            }


            // set session and timeout (60 minutes) for default
            Session["user"] = user.Id;
            if (rememberMe) Session.Timeout = (60*24)*300;
            else Session.Timeout = 60;

            Response.Redirect("Home.aspx");
        }
    }
}