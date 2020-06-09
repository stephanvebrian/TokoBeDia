using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.Cart
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region check session & set navbar & delete
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
                    var idStr = Request.QueryString["id"];

                    if (idStr.Length <= 0)
                    {
                        Response.Redirect("View.aspx");
                    }
                    else
                    {
                        try
                        {
                            int id = int.Parse(idStr);

                            var cart = CartRepository.findById(id);

                            ProductRepository.addStock(cart.ProductId, cart.Quantity);
                            CartRepository.remove(id);
                        }
                        catch (Exception ex)
                        {

                        }

                        Response.Redirect("View.aspx");
                    }
                }

            }
            else
            {
                Response.Redirect("../Home.aspx");
            }
            #endregion check session & set navbar & delete
        }
    }
}