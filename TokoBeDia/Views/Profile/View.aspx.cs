using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Profile
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
                    #endregion set navbar visible
                }

                lblId.Text = user.Id.ToString();
                lblRole.Text = user.Role.Name;
                lblName.Text = user.Name;
                lblEmail.Text = user.Email;
                lblGender.Text = user.Gender;            
            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
            #endregion check session & set navbar


        }
    }
}