<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="KPopZtation_Project.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
  
    <h1>Home Page</h1>

    <asp:Label ID="lblWelcomeMessage" runat="server"></asp:Label>
    
    <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
        <asp:Button ID="btnAddArtist" runat="server" Text="Add Artist" OnClick="btnAddArtist_Click" />
    <% } %>

    <asp:Repeater ID="rptArtists" runat="server">
    <ItemTemplate>
        <div class="card">
            <div class="card-header">
                <h3><%# Eval("ArtistName") %></h3>
            </div>
            <div class="card-body">
                <p>Artist ID: <%# Eval("ArtistID") %></p>
                <p>Artist Image: <%# Eval("ArtistImage") %></p>
                 
                <div>
                    <img class="artistImage" src='<%# ResolveUrl("~/Assets/Artists/" + Eval("ArtistImage")) %>' style="width: 200px; height: auto;" alt="Artist Image" />
                </div>

                <asp:Button ID="btnDetails" runat="server" Text="See Details" OnClick="btnDetails_Click" CommandArgument='<%# Eval("ArtistID") %>' />
            </div>
            <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
                <div class="card-footer">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CommandArgument='<%# Eval("ArtistID") %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Eval("ArtistID") %>' />
                </div>


            <% } %>

        </div>
    </ItemTemplate>
</asp:Repeater>




     


</asp:Content>
