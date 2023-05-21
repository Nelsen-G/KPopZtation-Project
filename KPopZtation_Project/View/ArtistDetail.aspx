<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KPopZtation_Project.View.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">


    <h1>Artist Details</h1>
  
     
            <div>
                <h2>Artist Information</h2>

                <div>
                <asp:Label ID="lbArtistID" runat="server" Text="Artist ID"></asp:Label>
                <asp:Label ID="lbID" runat="server" Text=""></asp:Label>
                </div>

                <div>
                <asp:Label ID="lbArtistName" runat="server" Text="Artist Name"></asp:Label>
                <asp:Label ID="lbName" runat="server" Text=""></asp:Label>
                </div>

                <div>
                <asp:Label ID="lbArtistImage" runat="server" Text="Artist Image"></asp:Label>
                <asp:Label ID="lbImage" runat="server" Text=""></asp:Label>
                </div>

            </div>
            <div>
                <h2>Albums</h2>

                <asp:Button ID="btnInsertAlbum" runat="server" Text="Add New Album" OnClick="btnInsertAlbum_Click" />

                <asp:Repeater ID="rptAlbums" runat="server">
                    <ItemTemplate>
                        <div>
                            
                            <p>Image: <%# Eval("AlbumImage") %></p>
                            <p>Name: <%# Eval("AlbumName") %></p>
                            <p>Price: <%# Eval("AlbumPrice") %></p>
                            <p>Description: <%# Eval("AlbumDescription") %></p>
                     
                            <div>
                             <asp:Button ID="btnAlbumDetail" runat="server" Text="See Album Details" OnClick="btnAlbumDetail_Click" CommandArgument='<%# Eval("AlbumID") %>' />
                            </div>


                            <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CommandArgument='<%# Eval("AlbumID") %>' />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Eval("AlbumID") %>' />
                            <% } %>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
    
  

</asp:Content>
