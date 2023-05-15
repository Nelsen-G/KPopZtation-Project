using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Factory
{
    public class AlbumFactory
    {
        public static Album addAlbum(String name, String description, int price, int stock, String image)
        {
            Album newAlbum = new Album();
            newAlbum.AlbumName = name;
            newAlbum.AlbumDescription = description;
            newAlbum.AlbumPrice = price;
            newAlbum.AlbumStock = stock;
            newAlbum.AlbumImage = image;

            return newAlbum;
        }
    }
}