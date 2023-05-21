<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="KPopZtation_Project.View.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>Insert Album</h1>

    <div>
        <asp:Label ID="lbName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
    </div>


    <div>
        <asp:Label ID="lbDescription" runat="server" Text="Description: "></asp:Label>
        <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbPrice" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbStock" runat="server" Text="Stock: "></asp:Label>
        <asp:TextBox ID="tbStock" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lbUploadImage" runat="server" Text="Upload Image"></asp:Label>
        <asp:FileUpload ID="fileUploadImage" runat="server" />
    </div>


    <div>
        <asp:Label ID="lbErrorMessage" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>

</asp:Content>
