<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="KPopZtation_Project.View.InsertArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">


    <h1>Insert Artist</h1>

    <div>
        <asp:Label ID="lbName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
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
