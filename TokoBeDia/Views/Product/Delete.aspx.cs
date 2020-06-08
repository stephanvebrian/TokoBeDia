using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Product
{
    public partial class Delete : System.Web.UI.Page
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

                    var paramId = Request.QueryString["id"];

                    if (paramId.Length == 0)
                    {
                        Response.Redirect("View.aspx");
                    }

                    var productId = int.Parse(paramId);
                    ProductRepository.delete(productId);

                    Response.Redirect("View.aspx");
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
                    #endregion set navbar visible
                    Response.Redirect("View.aspx");
                }
            }
            else
            {
                // Guest
                #region set admin navbar visible
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
                #endregion set navbar visible
                Response.Redirect("View.aspx");
            }
            #endregion check session & set navbar
        }
    }
}