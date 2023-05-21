<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="KPopZtation_Project.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
  
    <h1>Home Page</h1>

    <asp:Label ID="lblWelcomeMessage" runat="server"></asp:Label>
    


    <% foreach (var artist in artists)
{ %>
    <div>
        <p><%= artist.ArtistID %></p>
        <p><%= artist.ArtistName %></p>
        <p><%= artist.ArtistImage %></p>
        
        <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
            <a href="UpdateArtist.aspx?artistID=<%= artist.ArtistID %>">Update</a>
            
        <% } %>
    </div>

<% } %>




     <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
        <asp:Button ID="btnAddArtist" runat="server" Text="Add Artist" OnClick="btnAddArtist_Click" />
    <% } %>


</asp:Content>
