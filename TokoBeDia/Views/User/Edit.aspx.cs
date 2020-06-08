using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;

namespace TokoBeDia.Views.User
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

                        var userIdParam = Request.QueryString["id"];

                        if (userIdParam.Length > 0)
                        {
                            // Initialize drop down list
                            var roles = RoleRepository.findAll();
                            var status = StatusRepository.findAll();

                            ddlRole.DataSource = roles;
                            ddlRole.DataTextField = "Name";
                            ddlRole.DataValueField = "Id";
                            ddlRole.DataBind();

                            ddlStatus.DataSource = status;
                            ddlStatus.DataTextField = "Name";
                            ddlStatus.DataValueField = "Id";
                            ddlStatus.DataBind();

                            ddlGender.Items.Add(new ListItem("Male", "Male"));
                            ddlGender.Items.Add(new ListItem("Female", "Female"));
                            // 
                            var id = int.Parse(userIdParam);
                            if (user.Id == id)
                            {
                                Response.Redirect("View.aspx");
                                return;
                            }
                            var u = UserRepository.findById(id);

                            inputId.Text = u.Id.ToString();
                            ddlRole.SelectedValue = u.RoleId.ToString();
                            inputName.Text = u.Name;
                            inputEmail.Text = u.Email;
                            ddlGender.SelectedValue = u.Gender;
                            ddlStatus.SelectedValue = u.StatusId.ToString();

                        }else
                        {
                            Response.Redirect("View.aspx");
                        }

                    }
                    else
                    {
                        // Member or guest
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
            var statusId = int.Parse(ddlStatus.SelectedValue);

            UserRepository.editStatus(id, statusId);
            Response.Redirect("View.aspx");
        }
    }
}