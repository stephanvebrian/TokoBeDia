﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="TokoBeDia.Views.Product.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
</asp:Content>
<asp:Content ID="navbar" ContentPlaceHolderID="navbarContainer" runat="server">
    <div class="navbar navbar-expand">
        <div class="container-fluid">
            <div class="collapse navbar-collapse">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item" id="homeNavbar" runat="server">
                        <a class="nav-link" href="../Home.aspx">Home</a>
                    </li>
                    <li class="nav-item dropdown" id="profileNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Profile</a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="../Profile/View.aspx" id="profile_view" runat="server">View Profile</a>
                            <a class="dropdown-item" href="../Profile/Edit.aspx" id="profile_changeprof" runat="server">Change Profile</a>
                            <a class="dropdown-item" href="../Profile/ChangePassword.aspx" id="profile_changepass" runat="server">Change Password</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown" id="usersNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Users
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="../User/View.aspx" id="user_view" runat="server">View User</a>
                            <%--<a class="dropdown-item" href="#" id="user_update" runat="server">Update User</a>--%>
                            <%--<a class="dropdown-item" href="#" id="user_delete" runat="server">Delete User</a>--%>
                        </div>
                    </li>
                    <li class="nav-item dropdown" id="productsNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Products
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="../Product/View.aspx" id="product_view" runat="server">View Product</a>
                            <a class="dropdown-item" href="../Product/Add.aspx" id="product_insert" runat="server">Insert Product</a>
                            <%--<a class="dropdown-item" href="#" id="product_update" runat="server" visible="false">Update Product</a>--%>
                            <%--<a class="dropdown-item" href="#" id="product_delete" runat="server" visible="false">Delete Product</a>--%>
                        </div>
                    </li>
                    <li class="nav-item dropdown" id="productTypesNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Product Types
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown3">
                            <a class="dropdown-item" href="../ProductType/View.aspx" id="ptype_view" runat="server">View Product Types</a>
                            <a class="dropdown-item" href="../ProductType/Add.aspx" id="ptype_insert" runat="server">Insert Product Types</a>
                            <%--<a class="dropdown-item" href="#" id="ptype_update" runat="server" visible="false">Update Product Types</a>--%>
                            <%--<a class="dropdown-item" href="#" id="ptype_delete" runat="server" visible="false">Delete Product Types</a>--%>
                        </div>
                    </li>
                    <li class="nav-item" id="loginNavbar" runat="server">
                        <a class="nav-link" href="../Login.aspx">Login</a>
                    </li>
                    <li class="nav-item" id="registerNavbar" runat="server">
                        <a class="nav-link" href="../Register.aspx">Register</a>
                    </li>
                    <li class="nav-item" id="logoutNavbar" runat="server">
                        <a class="nav-link" href="../Logout.aspx">Logout</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="informationLabel" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home" style="min-height: 650px; height: 100%">
	    <div class="container">
		    <div class="row justify-content-center mt-5">
                <div><h4>Product/Add.aspx</h4></div>
		    </div>
	    </div>
	    <div class="container">
		    <div class="row justify-content-center mt-5">
                <div>
                    <h4 style="color: #532e43;">View Product</h4>
                     <div class="form-group">
                        <label for="id">ID</label>
                        <asp:TextBox ID="inputId" CssClass="form-control" runat="server" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                      </div>
                      <div class="form-group">
                        <label for="email">Name</label>
                        <asp:TextBox ID="inputName" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                        <small id="nameHelp" class="form-text text-muted">Must be filled</small>
                      </div>
                      <div class="form-group">
                        <label for="stock">Stock</label>
                        <asp:TextBox ID="inputStock" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        <small id="stockHelp" class="form-text text-muted">Must be filled</small>
                      </div>
                      <div class="form-group">
                        <label for="Product Type">Product Type</label>
                        <asp:TextBox ID="inputType" CssClass="form-control" runat="server" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                      </div>
                      <div class="form-group">
                        <label for="price">Price</label>
                        <asp:TextBox ID="inputPrice" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                      </div>                      
                      <asp:Label ID="formHelp" CssClass="form-text text-muted" runat="server" Text="Error" Visible="false"></asp:Label>
                      <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Add Product Type" OnClick="btnEdit_Click" />
                    <br />
                </div>
		    </div>
	    </div>
    </div>
</asp:Content>

<asp:Content ID="js" ContentPlaceHolderID="script" runat="server">
    <script src="../../Content/js/jquery-3.2.1.min.js"></script>
    <script src="../../Content/js/popper.js"></script>
    <script src="../../Content/js/bootstrap.min.js"></script>
</asp:Content>


