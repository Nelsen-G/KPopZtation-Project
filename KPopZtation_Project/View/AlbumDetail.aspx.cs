using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class AlbumDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            AlbumRepository albumRepository = new AlbumRepository();

            string albumPassedID = Request.QueryString["id"];
            int albumNumber = Convert.ToInt32(albumPassedID);

            int numberArtistID = albumRepository.getArtistFromAlbum(albumNumber);
            string artistID = numberArtistID.ToString();

            Response.Redirect("ArtistDetail.aspx?id=" + artistID);
        }
    }
}