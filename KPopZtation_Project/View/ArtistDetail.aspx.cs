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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtistRepository artistRepository = new ArtistRepository();
            AlbumRepository albumRepository = new AlbumRepository();

            if (!IsPostBack)
            {

                // ambil ArtistID
                string artistPassedID = Request.QueryString["id"];
                int artistNumber = Convert.ToInt32(artistPassedID);

                Artist art = artistRepository.selectArtist(artistNumber);

                lbID.Text = art.ArtistID.ToString();
                lbName.Text = art.ArtistName;
                lbImage.Text = art.ArtistImage;

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

        }

        protected void btnInsertAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertAlbum.aspx");
        }

        protected void btnAlbumDetail_Click(object sender, EventArgs e)
        {

        }
    }


}