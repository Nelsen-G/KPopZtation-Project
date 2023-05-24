using KPopZtation_Project.Factory;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class CartRepository
    {

        dbKPopEntities db = dbSingleton.getInstance();

        public Cart addCart(int customerID, int albumID, int quantity)
        {
            CartFactory cf = new CartFactory();

            Cart newCart = cf.makeCart(customerID, albumID, quantity); // This follows the ERD order

            db.Carts.Add(newCart);
            db.SaveChanges();

            return newCart;
        }


        public List<Cart> GetCartItemsByCustomer(int customerID)
        {
            return db.Carts.Where(c => c.CustomerID == customerID).ToList();

        }


        public int GetCustomerID(HttpContext context)
        {
            return int.Parse(context.Session["customerID"].ToString());
        }



    }
}