using KPopZtation_Project.Controller;
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
            AlbumRepository albumRepository = new AlbumRepository();

            string albumPassedID = Request.QueryString["id"];
            int albumNumber = Convert.ToInt32(albumPassedID);

            int numberArtistID = albumRepository.getArtistFromAlbum(albumNumber);
            string artistID = numberArtistID.ToString();

            Response.Redirect("ArtistDetail.aspx?id=" + artistID);
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AlbumController albumController = new AlbumController();

            string albumPassedID = Request.QueryString["id"];
            int albumNumber = Convert.ToInt32(albumPassedID);

            string errorMessage;

            string name = tbName.Text.Trim();
            string description = tbDescription.Text.Trim();
            string priceText = tbPrice.Text.Trim();
            string stockText = tbStock.Text.Trim();

            albumController.validateUpdateAlbum(albumNumber, name, description, priceText, stockText, fileUploadImage, out errorMessage);


            if (!string.IsNullOrEmpty(errorMessage))
            {
                lbErrorMessage.Text = errorMessage;
                return;
            }
        }
    }
}