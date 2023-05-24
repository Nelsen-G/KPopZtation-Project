using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Factory
{
    public class CartFactory
    {

        public Cart makeCart(int customerID, int albumID, int quantity)
        {
            Cart newCart = new Cart();
            newCart.CustomerID = customerID;
            newCart.AlbumID = albumID;
            newCart.Qty = quantity;

            return newCart;
        }

    }
}