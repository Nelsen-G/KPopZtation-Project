<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="UpdateAlbum.aspx.cs" Inherits="KPopZtation_Project.View.UpdateAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>Update Album</h1>

    <div>
        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
    </div>

    <div>
        <asp:Label ID="lbID" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="tbID" Enabled="false" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
    </div>


    <div>
        <asp:Label ID="lbUploadImage" runat="server" Text="Upload Image"></asp:Label>
        <asp:TextBox ID="tbImage" Enabled="false" runat="server"></asp:TextBox>
        <asp:FileUpload ID="fileUploadImage" runat="server" />
    </div>

    <div>
        <asp:Label ID="lbPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbStock" runat="server" Text="Stock"></asp:Label>
        <asp:TextBox ID="tbStock" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
    </div>


    <div>
        <asp:Label ID="lbErrorMessage" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    </div>

</asp:Content>
