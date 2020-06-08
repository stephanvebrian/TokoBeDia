using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.PaymentType
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

                            //var productType = ProductTypeRepository.findById(id);
                            var paymentType = PaymentTypeRepository.findById(id);

                            inputId.ReadOnly = true;

                            inputId.Text = paymentType.Id.ToString();
                            inputType.Text = paymentType.Type.ToString();

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
                #endregion check session & set navbar & view detail
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            formHelp.Visible = false;

            var id = int.Parse(inputId.Text);
            var type = inputType.Text;

            if (type.Length < 3)
            {
                formHelp.Text = "Name must consisft of 3 character or more";
                formHelp.Visible = true;
                return;
            }

            var checkName = PaymentTypeRepository.findByType(type);
            if (checkName != null)
            {
                formHelp.Text = "Type must be unique";
                formHelp.Visible = true;
                return;
            }

            PaymentTypeRepository.edit(id, type);

            Response.Redirect("View.aspx");
        }
    }
}