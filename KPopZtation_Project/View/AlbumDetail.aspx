<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="KPopZtation_Project.View.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <h1>Album Details</h1>

    <div>
        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
  
    </div>


            <div>
                <asp:Label ID="lbAlbumName" runat="server" Text=""></asp:Label>
            </div>

                <div>
                <asp:Label ID="lbAlbumImage" runat="server" Text="Album Image"></asp:Label>
                </div>
                
                <div>
                    <asp:Image ID="imgAlbum" runat="server" CssClass="albumImage" Width="200" />
                </div>


            <div>
                <asp:Label ID="lbDescription" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbPrice" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Label ID="lbStock" runat="server" Text=""></asp:Label>
            </div>
            <asp:Panel ID="pnlAddToCart" runat="server" Visible="false">
                <div>
                    <asp:Label ID="lbQuantity" runat="server" Text="Quantity: "></asp:Label>
       
                    <asp:TextBox ID="tbQuantity" runat="server"></asp:TextBox>
                </div>

                <div>
                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
                </div>

                <div>
                <asp:Label ID="lbErrorMessage" runat="server" Text=""></asp:Label>
            </div>

            </asp:Panel>



</asp:Content>
