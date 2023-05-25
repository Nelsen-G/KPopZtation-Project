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
            CustomerRepository customerRepository = new CustomerRepository();

            int customerID = customerRepository.GetCustomerID(HttpContext.Current);

            List<AlbumCartItem> cartItems = cartRepository.GetAlbumItemsByCustomer(customerID);

            rptCart.DataSource = cartItems;
            rptCart.DataBind();
        }


        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Button btnRemove = (Button)sender;
            int albumID = Convert.ToInt32(btnRemove.CommandArgument);

            CartRepository cartRepository = new CartRepository();
            CustomerRepository customerRepository = new CustomerRepository();
            AlbumRepository albumRepository = new AlbumRepository();

            int customerID = customerRepository.GetCustomerID(HttpContext.Current);

            int removedAlbumQuantity = cartRepository.GetAlbumQuantityInCart(customerID, albumID);

            albumRepository.AddStock(albumID, removedAlbumQuantity);

            cartRepository.RemoveAlbumFromCart(customerID, albumID);

            BindCartItems();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            CartRepository cartRepository = new CartRepository();
            TransactionsRepository transactionRepository = new TransactionsRepository();
            CustomerRepository customerRepository = new CustomerRepository();

            int customerID = customerRepository.GetCustomerID(HttpContext.Current);
            DateTime transactionDate = DateTime.Now;
            List<Cart> cartItems = cartRepository.GetCartItemsByCustomer(customerID);

            if (cartItems.Count > 0)
            {
                TransactionHeader transactionHeader = transactionRepository.AddTransactionHeader(customerID, transactionDate);
                List<TransactionDetail> transactionDetails = new List<TransactionDetail>();

                foreach (Cart cartItem in cartItems)
                {
                    TransactionDetail transactionDetail = transactionRepository.AddTransactionDetail(transactionHeader.TransactionID, cartItem.AlbumID, cartItem.Qty);
                    transactionDetails.Add(transactionDetail);
                }

                cartRepository.ClearCart(customerID);

                transactionRepository.SaveTransaction(transactionHeader, transactionDetails);


                Response.Redirect("HomePage.aspx");
            }
            
        }
    }
}