using KPopZtation_Project.Model;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class ArtistDetail : System.Web.UI.Page
    {
        public Artist artist;
        public List<Album> albums = new List<Album>();
        public int artistNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtistRepository artistRepository = new ArtistRepository();
            AlbumRepository albumRepository = new AlbumRepository();

            if (!IsPostBack)
            {

                // ambil ArtistID
                string artistPassedID = Request.QueryString["id"];
                artistNumber = Convert.ToInt32(artistPassedID);

                Artist art = artistRepository.selectArtist(artistNumber);

                lbID.Text = art.ArtistID.ToString();
                lbName.Text = art.ArtistName;
                lbImage.Text = art.ArtistImage;
                imgArtist.ImageUrl = ResolveUrl("~/Assets/Artists/" + art.ArtistImage);

                // albums owned by the artist
                albums = albumRepository.getAlbumsByArtist(artistNumber);
                rptAlbums.DataSource = albums;
                rptAlbums.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string albumID = btn.CommandArgument;

            Response.Redirect("UpdateAlbum.aspx?id=" + albumID);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string albumID = btn.CommandArgument;

            int albumNumber = Convert.ToInt32(albumID);
            AlbumRepository albumRepository = new AlbumRepository();
            albumRepository.deleteAlbum(albumNumber);

            Response.Redirect(Request.RawUrl);
        }
        protected void btnAlbumDetail_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string artistID = btn.CommandArgument;

            Response.Redirect("AlbumDetail.aspx?id=" + artistID);
        }

        protected void btnInsertAlbum_Click(object sender, EventArgs e)
        {
            string artistID = Request.QueryString["id"];
           
            Response.Redirect("InsertAlbum.aspx?id=" + artistID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx?");
        }
    }


}