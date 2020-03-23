<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TokoBeDia.Views.Login" %>
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
                        <a class="nav-link" href="Home.aspx">Home</a>
                    </li>
                    <li class="nav-item" id="profileNavbar" runat="server">
                        <a class="nav-link" href="#">Profile</a>
                    </li>
                    <li class="nav-item dropdown" id="usersNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Users
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="#" id="user_view" runat="server">View User</a>
                            <a class="dropdown-item" href="#" id="user_insert" runat="server">Insert User</a>
                            <a class="dropdown-item" href="#" id="user_update" runat="server">Update User</a>
                            <a class="dropdown-item" href="#" id="user_delete" runat="server">Delete User</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown" id="productsNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Products
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="#" id="product_view" runat="server">View Product</a>
                            <a class="dropdown-item" href="#" id="product_insert" runat="server">Insert Product</a>
                            <a class="dropdown-item" href="#" id="product_update" runat="server" visible="false">Update Product</a>
                            <a class="dropdown-item" href="#" id="product_delete" runat="server" visible="false">Delete Product</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown" id="productTypesNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Product Types
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown3">
                            <a class="dropdown-item" href="#" id="ptype_view" runat="server">View Product Types</a>
                            <a class="dropdown-item" href="#" id="ptype_insert" runat="server">Insert Product Types</a>
                            <a class="dropdown-item" href="#" id="ptype_update" runat="server" visible="false">Update Product Types</a>
                            <a class="dropdown-item" href="#" id="ptype_delete" runat="server" visible="false">Delete Product Types</a>
                        </div>
                    </li>
                    <li class="nav-item" id="loginNavbar" runat="server">
                        <a class="nav-link" href="Login.aspx">Login</a>
                    </li>
                    <li class="nav-item" id="registerNavbar" runat="server">
                        <a class="nav-link" href="Register.aspx">Register</a>
                    </li>
                    <li class="nav-item" id="logoutNavbar" runat="server">
                        <a class="nav-link" href="#">Logout</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="informationLabel" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="home" style="min-height: 600px">
        <div class="container">
            <div class="row justify-content-center">
                <div>
                    <h4 style="color: #532e43;">Login Page</h4>
                    
                      <div class="form-group">
                        <label for="email">Email address*</label>
                        <asp:TextBox ID="inputEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:Label ID="emailHelp" CssClass="form-text text-muted" runat="server" Text="Error" Visible="false"></asp:Label>
                      </div>
                      <div class="form-group">
                        <label for="password">Password*</label>
                        <asp:TextBox ID="inputPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="passwordHelp" CssClass="form-text text-muted" runat="server" Text="Error" Visible="false"></asp:Label>
                      </div>
                      <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" Text="Login Me!" OnClick="btnLogin_Click" />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
