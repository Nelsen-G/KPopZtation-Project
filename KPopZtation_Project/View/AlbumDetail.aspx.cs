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
    public partial class AlbumDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            AlbumRepository albumRepository = new AlbumRepository();

            if (!IsPostBack)
            {
                string albumID = Request.QueryString["id"];
                int albumNumber = Convert.ToInt32(albumID);

                Album album = albumRepository.selectAlbum(albumNumber);

                lbAlbumName.Text = "Album Name: " + album.AlbumName;
                lbDescription.Text = "Album Description: " + album.AlbumDescription;
                lbPrice.Text = "Price: Rp " + album.AlbumPrice.ToString();
                lbStock.Text = "Stock: " + album.AlbumStock.ToString();


                if (Session["user"] != null && Session["user"].ToString() == "Customer")
                {
                    pnlAddToCart.Visible = true;
                }


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

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            AlbumController albumController = new AlbumController();
            CartRepository cartRepository = new CartRepository();

            int loggedInCustomerID = customerRepository.GetCustomerID(HttpContext.Current);

            int albumID = int.Parse(Request.QueryString["id"]);

            string quantity = tbQuantity.Text;

            string errorMessage;

            albumController.validateAddToCart(loggedInCustomerID, albumID, quantity, out errorMessage);


            if (!string.IsNullOrEmpty(errorMessage))
            {
                lbErrorMessage.Text = errorMessage;
                return;
            }


        }
    }
}