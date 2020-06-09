using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Cart
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region check session & set navbar & view detail
                var userSession = Session["user"];

                if (userSession != null)
                {
                    // if user Logged on
                    var userId = int.Parse(userSession.ToString());
                    var user = UserRepository.findById(userId);

                    if (user.RoleId == 1)
                    {
                        // Admin
                        Response.Redirect("../Home.aspx");
                    }
                    else if (user.RoleId == 2)
                    {
                        // Member
                        #region set member navbar visible
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

                        var idStr = Request.QueryString["id"];

                        if (idStr.Length <= 0)
                        {
                            Response.Redirect("View.aspx");
                        }
                        else
                        {
                            int id = 0;
                            try
                            {
                                id = int.Parse(idStr);
                            }
                            catch (Exception ex)
                            {
                                Response.Redirect("View.aspx");
                            }

                            var cart = CartRepository.findById(id);

                            var products = ProductRepository.findAll();
                            ddlProductName.DataSource = products;
                            ddlProductName.DataTextField = "Name";
                            ddlProductName.DataValueField = "Id";
                            ddlProductName.DataBind();

                            inputId.ReadOnly = true;
                            inputId.Text = cart.Id.ToString();
                            inputProductIdOld.Text = cart.ProductId.ToString();

                            var product = ProductRepository.findById(cart.ProductId);
                            ddlProductName.Items.FindByValue(product.Id.ToString());
                            inputProductPrice.Text = product.Price.ToString();
                            inputProductStock.Text = product.Stock.ToString();
                            inputProductType.Text = product.ProductType.Name;

                            inputQtyOld.Text = cart.Quantity.ToString();
                            inputQty.Text = cart.Quantity.ToString();
                        }
                    }

                }
                else
                {
                    Response.Redirect("../Home.aspx");
                }
                #endregion check session & set navbar & view detail
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            formHelp.Visible = false;

            var productIdOld = int.Parse(inputProductIdOld.Text);
            //var productOld = ProductRepository.findById(productIdOld);

            var productId = int.Parse(ddlProductName.Items[ddlProductName.SelectedIndex].Value);
            var product = ProductRepository.findById(productId);

            var cartId = int.Parse(inputId.Text);
            
            var userSession = Session["user"];
            var userId = int.Parse(userSession.ToString());

            int oldQty = int.Parse(inputQtyOld.Text);
            int qty = int.Parse(inputQty.Text);

            ProductRepository.addStock(productIdOld, oldQty);

            if (qty <= 0)
            {
                formHelp.Text = "Quantity must be greater than 0";
                formHelp.Visible = true;
                return;
            }

            if (qty > product.Stock)
            {
                formHelp.Text = "Quantity must be smaller than product stock";
                formHelp.Visible = true;
                return;
            }

            ProductRepository.reduceStock(productId, qty);
            CartRepository.edit(cartId, userId, productId, qty);

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