using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Handler
{
    public class CartHandler
    {

        private CartRepository cartRepository;


        public CartHandler()
        {
            cartRepository = new CartRepository();
        }


        public void HandleInsertion(int customerID, int albumID, int quantity)
        {

            cartRepository.addCart(customerID, albumID, quantity);
        }

    }
}