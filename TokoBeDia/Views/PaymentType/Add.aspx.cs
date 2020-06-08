using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.PaymentType
{
    public partial class Add : System.Web.UI.Page
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

                }
                else if (user.RoleId == 2)
                {
                    // Member
                    Response.Redirect("../Home.aspx");
                }

            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
            #endregion check session & set navbar
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            formHelp.Visible = false;

            var type = inputType.Text;
            var error = false;

            if (type.Length < 3)
            {
                formHelp.Text = "Name must consisft of 3 character or more";
                formHelp.Visible = true;
                error = true;
                return;
            }

            var checkType = PaymentTypeRepository.findByType(type);
            if (checkType != null)
            {
                formHelp.Text = "Type must be unique";
                formHelp.Visible = true;
                error = true;
                return;
            }

            PaymentTypeRepository.add(type);

            Response.Redirect("View.aspx");
        }
    }
}