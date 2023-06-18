<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="KPopZtation_Project.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    
          <% if (Session["user"] == null){ %>
            
        <h1>Registration Page</h1>

        <div>
        <asp:Label ID="lbName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        
        </div>

        <div>
        <asp:Label ID="lbEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
       
        </div>

        <div>
        <asp:Label ID="lbGender" runat="server" Text="Gender: "></asp:Label>
        <asp:RadioButtonList ID="rbGender" runat="server">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        </div>

        <div>
        <asp:Label ID="lbAddress" runat="server" Text="Address: "></asp:Label>
        <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
        
        </div>

        <div>
        <asp:Label ID="lbPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
       

        </div>
        <asp:Label ID="lbErrorMessage" runat="server" Text=""></asp:Label>
        <div>

        </div>

        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        </div>

    <% } %>
</asp:Content>
