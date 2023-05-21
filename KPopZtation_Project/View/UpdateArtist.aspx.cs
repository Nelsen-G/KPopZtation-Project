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
    public partial class UpdateArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtistRepository artistRepository = new ArtistRepository();

            if (!IsPostBack)
            {
                string artistPassedID = Request.QueryString["id"];
                int artistNumber = Convert.ToInt32(artistPassedID);

                Artist a = artistRepository.selectArtist(artistNumber);
                
                tbID.Text = artistPassedID;
                //tbID.Text = a.ArtistID.ToString();
                tbName.Text = a.ArtistName;
                tbImage.Text = a.ArtistImage;


            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ArtistController artistController = new ArtistController();


            string artistPassedID = Request.QueryString["id"];
            int artistNumber = Convert.ToInt32(artistPassedID);

            string name = tbName.Text;

            string errorMessage;

            artistController.validateUpdate(artistNumber, name, fileUploadImage, out errorMessage);


            if (!string.IsNullOrEmpty(errorMessage))
            {
                lbErrorMessage.Text = errorMessage;
                return;
            }


            Response.Redirect("HomePage.aspx");

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}