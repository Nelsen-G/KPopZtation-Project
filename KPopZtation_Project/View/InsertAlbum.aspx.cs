using KPopZtation_Project.Controller;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class InsertAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string artistID = Request.QueryString["id"];
                   
                }
                else
                {
                    Response.Redirect("ArtistDetail.aspx");
                }
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AlbumController albumController = new AlbumController();
            string errorMessage;

            string name = tbName.Text.Trim();
            string description = tbDescription.Text.Trim();
            string priceText = tbPrice.Text.Trim();
            string stockText = tbStock.Text.Trim();

            string artistID = Request.QueryString["id"];

            albumController.validateInsertAlbum(name, description, priceText, stockText, fileUploadImage, out errorMessage, artistID);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                lbErrorMessage.Text = errorMessage;
                return;
            }


            Response.Redirect(Request.RawUrl);


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            AlbumRepository albumRepository = new AlbumRepository();

            string artistID = Request.QueryString["id"];
      
            Response.Redirect("ArtistDetail.aspx?id=" + artistID);
        }
    }
}