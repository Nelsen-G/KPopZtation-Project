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
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlbumRepository albumRepository = new AlbumRepository();

            if (!IsPostBack)
            {

                // ambil albumID
                string albumPassedID = Request.QueryString["id"];
                int albumNumber = Convert.ToInt32(albumPassedID);

                Album abm = albumRepository.selectAlbum(albumNumber);

                tbID.Text = abm.ArtistID.ToString();
                tbName.Text = abm.AlbumName;
                tbImage.Text = abm.AlbumImage;
                tbPrice.Text = abm.AlbumPrice.ToString();
                tbStock.Text = abm.AlbumStock.ToString();
                tbDescription.Text = abm.AlbumDescription;


            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArtistDetail.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}