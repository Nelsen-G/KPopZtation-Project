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
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
            }
        }


        protected void BindCartItems()
        {
            CartRepository cartRepository = new CartRepository();

            int customerID = cartRepository.GetCustomerID(HttpContext.Current);

            List<AlbumCartItem> cartItems = cartRepository.GetAlbumItemsByCustomer(customerID);

            rptCart.DataSource = cartItems;
            rptCart.DataBind();
        }


        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Button btnRemove = (Button)sender;
            int albumID = Convert.ToInt32(btnRemove.CommandArgument);

            CartRepository cartRepository = new CartRepository();
            int customerID = cartRepository.GetCustomerID(HttpContext.Current);

            cartRepository.RemoveAlbumFromCart(customerID, albumID);

            BindCartItems();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}