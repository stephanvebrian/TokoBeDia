using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Product
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
                        #endregion set navbar visible

                        var productIdParam = Request.QueryString["id"];

                        if (productIdParam.Length > 0)
                        {
                            var productId = int.Parse(productIdParam);

                            var p = ProductRepository.findById(productId);

                            inputId.Text = p.Id.ToString();
                            inputType.Text = p.ProductType.Name;
                            inputName.Text = p.Name;
                            inputPrice.Text = p.Price.ToString();
                            inputStock.Text = p.Stock.ToString();

                        }
                        else
                        {
                            Response.Redirect("View.aspx");
                        }

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
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            formHelp.Visible = false;

            var id = int.Parse(inputId.Text);
            var name = inputName.Text;
            var stock = int.Parse(inputStock.Text);
            var price = int.Parse(inputPrice.Text);

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

            if (price < 1000 && (price % 1000) != 0)
            {
                formHelp.Text = "Price must be above 1000 and multiply of 1000";
                formHelp.Visible = true;
                return;
            }

            ProductRepository.edit(id, name, stock, price);

            Response.Redirect("View.aspx");
        }
    }
}