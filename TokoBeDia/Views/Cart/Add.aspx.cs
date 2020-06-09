using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Handler;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Cart
{
    public partial class Add : System.Web.UI.Page
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

                        cartNavbar.Visible = true;
                        cart_view.Visible = true;
                        cart_insert.Visible = true;
                        #endregion set navbar visible

                        var products = ProductRepository.findAll();

                        ddlProductName.DataSource = products;
                        ddlProductName.DataTextField = "Name";
                        ddlProductName.DataValueField = "Id";
                        ddlProductName.DataBind();

                        if (products.Count >= 1)
                        {
                            var product = products[0];

                            inputProductPrice.Text = product.Price.ToString();
                            inputProductStock.Text = product.Stock.ToString();
                            inputProductType.Text = product.ProductType.Name;
                        }

                    }

                }
                else
                {
                    // Guest
                    Response.Redirect("View.aspx");
                }
                #endregion check session & set navbar
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            formHelp.Visible = false;
            var productId = int.Parse(ddlProductName.Items[ddlProductName.SelectedIndex].Value);
            var product = ProductRepository.findById(productId);

            var userSession = Session["user"];
            var userId = int.Parse(userSession.ToString());

            int qty = int.Parse(inputQty.Text);

            if(qty <= 0)
            {
                formHelp.Text = "Quantity must be greater than 0";
                formHelp.Visible = true;
                return;
            }

            if(qty > product.Stock)
            {
                formHelp.Text = "Quantity must be smaller than product stock";
                formHelp.Visible = true;
                return;
            }

            ProductRepository.reduceStock(productId, qty);
            CartHandler.add(userId, productId, qty);

            Response.Redirect("View.aspx");
        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var productId = ddlProductName.Items[ddlProductName.SelectedIndex].Value;

            var product = ProductRepository.findById(int.Parse(productId));
            inputProductPrice.Text = product.Price.ToString();
            inputProductStock.Text = product.Stock.ToString();
            inputProductType.Text = product.ProductType.Name;
        }
    }
}