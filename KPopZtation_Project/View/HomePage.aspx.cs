using KPopZtation_Project.Repository;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class HomePage : System.Web.UI.Page
    {

        public List<Artist> artists = new List<Artist>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["user"] != null && Session["user"].ToString() == "Customer")
                {
                    if (Session["username"] != null)
                    {
                        lblWelcomeMessage.Text = "Welcome, " + Session["username"].ToString();
                    }
                }


                ArtistRepository artistRepository = new ArtistRepository();
                artists = artistRepository.getAllArtists();

                rptArtists.DataSource = artists;
                rptArtists.DataBind();

            }


        }

        protected void btnAddArtist_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertArtist.aspx");
        }

        
   
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string artistID = btn.CommandArgument;

            Response.Redirect("UpdateArtist.aspx?id=" + artistID);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string artistID = btn.CommandArgument;

            int artistNumber = Convert.ToInt32(artistID);
            ArtistRepository artistRepository = new ArtistRepository();
            artistRepository.deleteArtist(artistNumber);

            Response.Redirect(Request.RawUrl);
        }
    }
}