<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TokoBeDia.Views.Home" %>

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
                    <li class="nav-item dropdown" id="profileNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Profile</a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="~/Views/Profile/View.aspx" id="profile_view" runat="server">View Profile</a>
                            <a class="dropdown-item" href="~/Views/Profile/Edit.aspx" id="profile_changeprof" runat="server">Change Profile</a>
                            <a class="dropdown-item" href="~/Views/Profile/ChangePassword.aspx" id="profile_changepass" runat="server">Change Password</a>
                        </div>
                    </li>
                    <li class="nav-item dropdown" id="usersNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Users
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="~/Views/User/View.aspx" id="user_view" runat="server">View User</a>
                            <%--<a class="dropdown-item" href="#" id="user_update" runat="server">Update User</a>--%>
                            <%--<a class="dropdown-item" href="#" id="user_delete" runat="server">Delete User</a>--%>
                        </div>
                    </li>
                    <li class="nav-item dropdown" id="productsNavbar" runat="server">
                        <a class="nav-link dropdown-toggle" href="#" role="button"
                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Products
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown2">
                            <a class="dropdown-item" href="~/Views/Product/View.aspx" id="product_view" runat="server">View Product</a>
                            <a class="dropdown-item" href="~/Views/Product/Add.aspx" id="product_insert" runat="server">Insert Product</a>
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
                            <a class="dropdown-item" href="~/Views/ProductType/View.aspx" id="ptype_view" runat="server">View Product Types</a>
                            <a class="dropdown-item" href="~/Views/ProductType/Add.aspx" id="ptype_insert" runat="server">Insert Product Types</a>
                            <%--<a class="dropdown-item" href="#" id="ptype_update" runat="server" visible="false">Update Product Types</a>--%>
                            <%--<a class="dropdown-item" href="#" id="ptype_delete" runat="server" visible="false">Delete Product Types</a>--%>
                        </div>
                    </li>
                    <li class="nav-item" id="loginNavbar" runat="server">
                        <a class="nav-link" href="Login.aspx">Login</a>
                    </li>
                    <li class="nav-item" id="registerNavbar" runat="server">
                        <a class="nav-link" href="Register.aspx">Register</a>
                    </li>
                    <li class="nav-item" id="logoutNavbar" runat="server">
                        <a class="nav-link" href="Logout.aspx">Logout</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="informationLabel" runat="server">
</asp:Content>

<asp:Content ID="contentWebsite" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="home" style="height: 100%;min-height: 650px">
	    <div class="container">
		    <div class="row justify-content-center mt-5">
                <div><h4><b>Welcome back,</b> <i id="role" runat="server"></i>!</h4></div>
                <br />
                <div><h4><asp:Label ID="notificationcontainer" runat="server" Text="Label"></asp:Label></h4></div>
		    </div>
	    </div>
        <div class="container" runat="server">
		    <div class="row justify-content-center mt-5">
                <div>
                    <div><h4 style="text-align:center;">Top 5 Product</h4></div>
                    <div><h5 style="text-align: center;">Please go to /Product/View to view all product</h5></div>
                    <asp:GridView ID="gv_ViewProductAdmin" AutoGenerateColumns="false" UseAccessibleHeader="true" 
                        DataKeyNames="Id"
                        CssClass="table table-condensed table-hover" HorizontalAlign="Center" Width="70%" runat="server">
                        <Columns>  
                            <asp:BoundField DataField="Id" HeaderText="Product ID" />  
                            <asp:BoundField DataField="Name" HeaderText="Product Name" />  
                            <asp:BoundField DataField="Stock" HeaderText="Product Stock" />  
                            <asp:BoundField DataField="ProductType.Name" HeaderText="Product Type" />
                            <asp:BoundField DataField="Stock" HeaderText="Product Quantity" />
                            
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/Product/Detail.aspx?id={0}"  Text="Detail"/>
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/Product/Edit.aspx?id={0}"  Text="Edit" />
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/Product/Delete.aspx?id={0}"  Text="Delete" />
                        </Columns> 
                    </asp:GridView>
                    <asp:GridView ID="gv_ViewProductPublic" AutoGenerateColumns="false" UseAccessibleHeader="true" 
                        DataKeyNames="Id"
                        CssClass="table table-condensed table-hover" HorizontalAlign="Center" Width="70%" runat="server">
                        <Columns>  
                            <asp:BoundField DataField="Id" HeaderText="Product ID" />  
                            <asp:BoundField DataField="Name" HeaderText="Product Name" />  
                            <asp:BoundField DataField="Stock" HeaderText="Product Stock" />  
                            <asp:BoundField DataField="ProductType.Name" HeaderText="Product Type" />
                            <asp:BoundField DataField="Stock" HeaderText="Product Quantity" />
                            
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/Product/Detail.aspx?id={0}"  Text="Detail"/>
                        </Columns> 
                    </asp:GridView>
                </div>
            </div>
	    </div>
    </div>

</asp:Content>


<asp:Content ID="js" ContentPlaceHolderID="script" runat="server">
    <script src="../Content/js/jquery-3.2.1.min.js"></script>
    <script src="../Content/js/popper.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
</asp:Content>
