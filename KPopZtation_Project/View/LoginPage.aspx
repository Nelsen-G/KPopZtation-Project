<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="KPopZtation_Project.View.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>Login Page</h1>

    <div>
        <asp:Label ID="lbEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:CheckBox ID="cbRemember" runat="server" Text="Remember Me" />
    </div>

    <div>
        <asp:Label ID="lbErrorMessage" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
    </div>

</asp:Content>