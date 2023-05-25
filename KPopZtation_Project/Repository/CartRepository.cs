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


        public int GetAlbumQuantityInCart(int customerID, int albumID)
        {
            Cart cartItem = db.Carts.FirstOrDefault(c => c.CustomerID == customerID && c.AlbumID == albumID);
            return cartItem.Qty;
    
        }

        public List<AlbumCartItem> GetAlbumItemsByCustomer(int customerID)
        {
            List<AlbumCartItem> albumItems = db.Carts
                .Where(c => c.CustomerID == customerID)
                .Join(
                    db.Albums,
                    cart => cart.AlbumID,
                    album => album.AlbumID,
                    (cart, album) => new AlbumCartItem
                    {
                        AlbumID = album.AlbumID,
                        AlbumName = album.AlbumName,
                        AlbumImage = album.AlbumImage,
                        AlbumPrice = album.AlbumPrice,
                        AlbumQuantity = cart.Qty
                    }
                )
                .ToList();

            return albumItems;
        }


        public void RemoveAlbumFromCart(int customerID, int albumID)
        {
            Cart cartItem = db.Carts.FirstOrDefault(c => c.CustomerID == customerID && c.AlbumID == albumID);

            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
        }


        public void ClearCart(int customerID)
        {
            List<Cart> cartItems = db.Carts.Where(c => c.CustomerID == customerID).ToList();
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }

    }


    public class AlbumCartItem
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string AlbumImage { get; set; }
        public decimal AlbumPrice { get; set; }
        public int AlbumQuantity { get; set; }
    }

}