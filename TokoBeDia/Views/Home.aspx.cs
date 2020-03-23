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
                User user = UserRepository.findById(userId);

            }else
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

                role.InnerText = "Guest";
                notificationcontainer.InnerHtml += " <h4>Please Login first</h4>"; ;
            }
            

        }
    }
}