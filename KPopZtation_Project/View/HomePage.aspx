<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="KPopZtation_Project.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
  
    <h1>Home Page</h1>

    <asp:Label ID="lblWelcomeMessage" runat="server"></asp:Label>
    


    <asp:Repeater ID="rptArtists" runat="server">
    <ItemTemplate>
        <div>
            <p><%# Eval("ArtistID") %></p>
            <p><%# Eval("ArtistName") %></p>
            <p><%# Eval("ArtistImage") %></p>
            
            <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CommandArgument='<%# Eval("ArtistID") %>' />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Eval("ArtistID") %>' />
            <% } %>
        </div>
    </ItemTemplate>
</asp:Repeater>




     <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
        <asp:Button ID="btnAddArtist" runat="server" Text="Add Artist" OnClick="btnAddArtist_Click" />
    <% } %>


</asp:Content>
