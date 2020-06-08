using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.ProductType
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

                            var productType = ProductTypeRepository.findById(id);

                            inputId.ReadOnly = true;

                            inputId.Text = productType.Id.ToString();
                            inputName.Text = productType.Name;
                            inputDescription.Text = productType.Description;

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
            var name = inputName.Text;
            var desc = inputDescription.Text;

            if (name.Length < 5)
            {
                formHelp.Text = "Name must consisft of 5 character or more";
                formHelp.Visible = true;
                return;
            }

            var checkName = ProductTypeRepository.findByName(name);
            if (checkName != null)
            {
                formHelp.Text = "Name must be unique";
                formHelp.Visible = true;
                return;
            }

            if (desc.Length <= 0)
            {
                formHelp.Text = "Description cannot be empty";
                formHelp.Visible = false;
                return;
            }

            ProductTypeRepository.edit(id, name, desc);

            Response.Redirect("View.aspx");
        }
    }
}