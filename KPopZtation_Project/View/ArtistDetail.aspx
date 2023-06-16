<%@ Page Title="" Language="C#" MasterPageFile="~/View/MenuNavigation.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KPopZtation_Project.View.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div>
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"  />
    </div>
    

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
                
                <div>
                    <asp:Image ID="imgArtist" runat="server" CssClass="artistImage" Width="200" />
                </div>

            </div>
            <div>
                <h2>Albums</h2>

                        <% if(Session["user"].ToString() == "Admin") {%>
        <asp:Button ID="btnInsertAlbum" runat="server" Text="Insert Album" OnClick="btnInsertAlbum_Click"  />
        <% } %>
                         
                <asp:Repeater ID="rptAlbums" runat="server">
                    <ItemTemplate>
                        <div>
                            <asp:LinkButton runat="server" ID="btnAlbumDetail" OnClick="btnAlbumDetail_Click" CommandArgument='<%# Eval("AlbumID") %>' style="text-decoration: none;color:black;">
                            <p>Image: <%# Eval("AlbumImage") %></p>
                            <div>
                                <img class="albumImage" src='<%# ResolveUrl("~/Assets/Albums/" + Eval("AlbumImage")) %>' style="width: 200px; height: auto;" alt="Album Image" />
                            </div>


                            <p>Name: <%# Eval("AlbumName") %></p>
                            <p>Price: <%# Eval("AlbumPrice") %></p>
                            <p>Description: <%# Eval("AlbumDescription") %></p>


                            <% if (Session["user"] != null && Session["user"].ToString() == "Admin") { %>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CommandArgument='<%# Eval("AlbumID") %>' />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Eval("AlbumID") %>' />
                           
                            <% } %>

                            <hr />
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
    
  

</asp:Content>
