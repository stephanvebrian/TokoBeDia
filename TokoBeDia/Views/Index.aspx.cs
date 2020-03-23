using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokoBeDia.Views
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var productData = $"<div class='col-xl-4 col-md-6'>    <div class='product'>    <div class='product_content'>    <div class='product_info d-flex flex-row align-items-start justify-content-start'>    <div style='width: 100%;'>    <div class='product_name'>    <p>#PR001</p>    <p style='font-size: 20px; color: #4a4a4a;'>Laptop MSI GE62 2QE</p>    <p style='font-size: 18px;'>Rp. 250000</p>    <p style=''>Qty : 25</p>    </div>    <br>    <div class='product_category'><a href='category.html'>Type</a></div>    </div>    </div>    <div class='product_buttons'>    <div class='text-right d-flex flex-row align-items-start justify-content-start'>    <div class='product_button product_fav text-center d-flex flex-column align-items-center justify-content-center'>    <div>    <div><i class='fa fa-plus' aria-hidden='true'></i></div>    </div>    </div>    </div>    </div>    </div>    </div>    </div>";
            product_container.InnerHtml += productData;
            product_container.InnerHtml += productData;

            // Guest:
            // Visible : View Product, Login

            loginNavbar.Visible = true;
        }
    }
}