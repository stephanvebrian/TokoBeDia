﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="TokoBeDia.Views.User.Edit" %>
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
                    <li class="nav-item dropdown" id="paymentTypesNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Payment Types
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="~/Views/PaymentType/View.aspx" id="paymenttype_view" runat="server">View Payment Types</a>
                            <a class="dropdown-item" href="~/Views/PaymentType/Add.aspx" id="paymenttype_insert" runat="server">Insert Payment Types</a>
                            <%--<a class="dropdown-item" href="#" id="paymenttype_update" runat="server" visible="false">Update Payment Types</a>--%>
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
                    <li class="nav-item dropdown" id="cartNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Cart
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="../Cart/View.aspx" id="cart_view" runat="server">View Cart</a>
                            <a class="dropdown-item" href="../Cart/Add.aspx" id="cart_insert" runat="server">Insert Cart</a>
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
                <div><h4>User/Edit.aspx</h4></div>
		    </div>
	    </div>
	    <div class="container">
		    <div class="row justify-content-center mt-5">
                <div>
                    <h4 style="color: #532e43;">Edit User</h4>
                     <div class="form-group">
                        <label for="id">ID</label>
                        <asp:TextBox ID="inputId" CssClass="form-control" runat="server" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                      </div>
                      <div class="form-group">
                        <label for="role">Role</label>
                         <asp:DropDownList ID="ddlRole" CssClass="form-control" runat="server" ReadOnly="true"></asp:DropDownList>
                      </div>
                      <div class="form-group">
                        <label for="email">Name</label>
                        <asp:TextBox ID="inputName" CssClass="form-control" runat="server" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                      </div>
                      <div class="form-group">
                        <label for="email">Email</label>
                        <asp:TextBox ID="inputEmail" CssClass="form-control" runat="server" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                      </div>
                      <div class="form-group">
                        <label for="gender">Gender</label>
                        <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server" ReadOnly="true" Enabled="false"></asp:DropDownList>
                      </div>
                      <div class="form-group">
                        <label for="status">Status</label>
                        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server"></asp:DropDownList>
                      </div>                      
                      <asp:Label ID="formHelp" CssClass="form-text text-muted" runat="server" Text="Error" Visible="false"></asp:Label>
                      <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="Update User" OnClick="btnEdit_Click" />
                    <br />
                </div>
		    </div>
	    </div>
    </div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="script" runat="server">
</asp:Content>
