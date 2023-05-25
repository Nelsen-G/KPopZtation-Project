<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="TransactionsPage.aspx.cs" Inherits="KPopZtation_Project.View.TransactionsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">


    <h1>Transactions Page</h1>

    <asp:Repeater ID="rptTransactions" runat="server">
    <ItemTemplate>
        <div class="card">
            <div class="card-body">
                <h3>Transaction ID: <%# Eval("TransactionID") %></h3>
                <p>Transaction Date: <%# Eval("TransactionDate", "{0:dd/MM/yyyy}") %></p>
                <p>Customer Name: <%# Eval("CustomerName") %></p>

                <asp:Repeater ID="rptAlbums" runat="server" DataSource='<%# Eval("Albums") %>'>
                    <ItemTemplate>
                        <div>
                            <p>Image: <%# Eval("AlbumImage") %></p>
                            <img class="albumImage" src='<%# ResolveUrl("~/Assets/Albums/" + Eval("AlbumImage")) %>' style="width: 200px; height: auto;" alt="Album Image" />
                            <p>Album Name: <%# Eval("AlbumName") %></p>
                            <p>Quantity: <%# Eval("Qty") %></p>
                            <p>Price: <%# Eval("AlbumPrice") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>


</asp:Content>
