using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userSession = Session["user"];

            if (userSession != null)
            {
                // if user Logged on
                var userId = int.Parse(userSession.ToString());
                var user = UserRepository.findById(userId);

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
                #endregion set navbar visible
            }
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            emailHelp.Visible = false;
            nameHelp.Visible = false;
            passwordHelp.Visible = false;
            genderHelp.Visible = false;
            registerHelp.Visible = false;

            var email = inputEmail.Text;
            var name = inputName.Text;
            var password = inputPassword.Text;
            var confirmPassword = inputConfirmPassword.Text;
            var gender = inputGender.SelectedValue;
            bool error = false;

            #region validate input
            if (email.Length <= 0)
            {
                emailHelp.Text = "Email cannot be empty, ";
                emailHelp.Visible = true;
                error = true;
            }

            if(name.Length <= 0)
            {
                nameHelp.Text = "Name cannot be empty, ";
                nameHelp.Visible = true;
                error = true;
            }

            if(password.Length <= 0)
            {
                passwordHelp.Text = "Password cannot be empty, ";
                passwordHelp.Visible = true;
                error = true;
            }
            else if (!password.Equals(confirmPassword))
            {
                var errorStr = "Password not matches, ";
                passwordHelp.Text = errorStr;
                passwordHelp.Visible = true;
                error = true;
            }

            if(gender.Length == 0)
            {
                genderHelp.Text = "Gender Must choose one, ";
                genderHelp.Visible = true;
                error = true;
            }

            var uByEmail = UserRepository.findByEmail(email);
            if(uByEmail != null)
            {
                emailHelp.Text = "Email already registered";
                emailHelp.Visible = true;
                error = true;
            }
            #endregion validate input

            if (error == false)
            {
                bool isSucces = UserRepository.add(email, name, password, gender);
                string msg = isSucces ? "Register Success" : "Something wrong";

                inputEmail.Text = "";
                inputName.Text = "";
                inputPassword.Text = "";
                inputConfirmPassword.Text = "";
                inputGender.ClearSelection();

                registerHelp.Text = msg;
                registerHelp.Visible = true;
            }
        }
    }
}