using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Profile
{
    public partial class Edit : System.Web.UI.Page
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

                    inputId.ReadOnly = true;
                    inputId.Text = user.Id.ToString();
                    inputRole.ReadOnly = true;
                    inputRole.Text = user.Role.Name;
                    inputName.Text = user.Name;
                    inputEmail.Text = user.Email;
                    //inputPassword.Text = user.Password;
                    inputGender.SelectedValue = user.Gender;
                    inputStatus.ReadOnly = true;
                    inputStatus.Text = user.Status.Name;
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

            var id = int.Parse(inputId.Text);
            var name = inputName.Text;
            var email = inputEmail.Text;
            //var password = inputPassword.Text;
            var gender = inputGender.SelectedValue;

            if (name.Length <= 0)
            {
                formHelp.Text = "Name cannot be empty";
                formHelp.Visible = true;
                return;
            }

            if (email.Length <= 0)
            {
                formHelp.Text = "Email cannot be empty";
                formHelp.Visible = true;
                return;
            }

            var userByEmail = UserRepository.findByEmail(email);

            if (userByEmail != null)
            {
                formHelp.Text = "Email already taken by another user";
                formHelp.Visible = true;
                return;
            }

            UserRepository.edit(id, name, email, gender);
            formHelp.Text = "Update Profile Successfully";
            formHelp.Visible = true;

            Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}