using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Product
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
                    #endregion set navbar visible

                    var productTypes = ProductTypeRepository.findAll();

                    ddlType.DataSource = productTypes;
                    ddlType.DataTextField = "Name";
                    ddlType.DataValueField = "Id";
                    ddlType.DataBind();

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

            var name = inputName.Text;
            var stock = 0;
            try
            {
                stock = int.Parse(inputStock.Text);
            }
            catch (Exception ex)
            {

            }
            var productType = int.Parse(ddlType.SelectedValue);
            var price = 0;
            try
            {
                price = int.Parse(inputPrice.Text);
            }
            catch (Exception ex)
            {

            }
            
            if (name.Length <= 0)
            {
                formHelp.Text = "Name must be filled";
                formHelp.Visible = true;
                return;
            }

            if (stock < 1)
            {
                formHelp.Text = "Stock must be 1 or more";
                formHelp.Visible = true;
                return;
            }

            if (price < 1000 && (price % 1000) != 0 )
            {
                formHelp.Text = "Price must be above 1000 and multiply of 1000";
                formHelp.Visible = true;
                return;
            }

            ProductRepository.add(name, productType, price, stock);
            Response.Redirect("View.aspx");
        }
    }
}