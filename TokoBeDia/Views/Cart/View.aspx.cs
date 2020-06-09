using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Cart
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
                    Response.Redirect("../Home.aspx");

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
                    gv_ViewMemberCart.Visible = true;
                }

            }
            else
            {
                // Guest
                Response.Redirect("../Home.aspx");
            }
            #endregion check session & set navbar

            refreshTable();
        }

        private void refreshTable()
        {
            int totalQty = 0;
            int totalPrice = 0;
            var carts = CartRepository.findByUserId(int.Parse(Session["user"].ToString()));

            var listCart = new List<dynamic>();

            foreach (var item in carts)
            {
                var product = ProductRepository.findById(item.ProductId);
                totalQty += item.Quantity;
                totalPrice = (int.Parse(product.Price.ToString()) * item.Quantity) + totalPrice;
                var obj = new
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = product.Name,
                    Quantity = item.Quantity,
                    Subtotal = int.Parse(product.Price.ToString()) * item.Quantity
                };

                listCart.Add(obj);
            }
            
            gv_ViewMemberCart.DataSource = listCart;
            gv_ViewMemberCart.DataBind();

            totalQuantity.Text = totalQty.ToString();
            grandTotal.Text = totalPrice.ToString();
        }
    }
}