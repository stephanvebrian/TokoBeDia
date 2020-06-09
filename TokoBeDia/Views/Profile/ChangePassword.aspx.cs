using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Profile
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                        cartNavbar.Visible = false;
                        cart_view.Visible = false;
                        cart_insert.Visible = false;
                        #endregion set navbar visible

                    }
                    else if (user.RoleId == 2)
                    {
                        // Member
                        #region set admin navbar visible
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
                    }

                }
                else
                {
                    Response.Redirect("../Home.aspx");
                }
                #endregion check session & set navbar
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            formHelp.Visible = false;
            var userSession = Session["user"];
            var userId = int.Parse(userSession.ToString());
            var user = UserRepository.findById(userId);

            var oldPassword = inputOldPassword.Text;
            var newPassword = inputPassword.Text;
            var confirmPassword = inputConfirmPassword.Text;

            var u = UserRepository.findById(userId);
            if (!u.Password.Equals(oldPassword))
            {
                formHelp.Text = "Old password not matches database's";
                formHelp.Visible = true;
                return;
            }

            if (!newPassword.Equals(confirmPassword))
            {
                formHelp.Text = "New Password not matches with Confirm";
                formHelp.Visible = true;
                return;
            }

            UserRepository.editPassword(userId, newPassword);

            inputPassword.Text = "";
            formHelp.Text = "Change Password successfully";
            formHelp.Visible = true;
        }
    }
}