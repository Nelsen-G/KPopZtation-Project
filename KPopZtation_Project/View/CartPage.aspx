<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="KPopZtation_Project.View.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">


    <h1>Cart Page</h1>

    <asp:Repeater ID="rptCart" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3><%# Eval("AlbumName") %></h3>
                        </div>
                        <div class="card-body">
                            <p>Album Image: <%# Eval("AlbumImage") %></p>
                            <p>Album ID: <%# Eval("AlbumID") %></p>
                            <p>Quantity: <%# Eval("AlbumQuantity") %></p>
                            <p>Price: <%# Eval("AlbumPrice") %></p>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" CommandArgument='<%# Eval("AlbumID") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div>
                <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
            </div>


</asp:Content>
