using KPopZtation_Project.Factory;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace KPopZtation_Project.Repository
{
    public class AlbumRepository
    {

        DatabaseKPopEntities2 db = dbSingleton.getInstance();

        public static List<Album> GetAlbumsFromRepo()
        {
            DatabaseKPopEntities2 db = new DatabaseKPopEntities2();
            return db.Albums.ToList();
        }

        public List<Album> getAlbumsByArtist(int artistID)
        {
            return db.Albums.Where(a => a.ArtistID == artistID).ToList();
        }

        public Album selectAlbum(int albumNumber)
        {
            return db.Albums.FirstOrDefault(a => a.AlbumID == albumNumber);
        }

        public void SubtractStock(int albumID, int quantity)
        {
            AlbumRepository albumRepository = new AlbumRepository();

            Album album = albumRepository.selectAlbum(albumID);

            if (album != null)
            {

                album.AlbumStock -= quantity;

                albumRepository.updateAlbum(album.AlbumID, album.AlbumName, album.AlbumDescription, album.AlbumPrice, album.AlbumStock, album.AlbumImage);

            }
        }

        public void AddStock(int albumID, int quantity)
        {
            AlbumRepository albumRepository = new AlbumRepository();

            Album album = albumRepository.selectAlbum(albumID);

            if (album != null)
            {

                album.AlbumStock += quantity;

                albumRepository.updateAlbum(album.AlbumID, album.AlbumName, album.AlbumDescription, album.AlbumPrice, album.AlbumStock, album.AlbumImage);

            }
        }

        public int getArtistFromAlbum(int albumNumber)
        {
            int artistID = 0;

            var album = db.Albums.FirstOrDefault(a => a.AlbumID == albumNumber);

            if (album != null)
            {
                artistID = album.ArtistID;
            }

            return artistID;
        }

        public Album createAlbum(int foreignArtistID, string name, string description, int price, int stock, string fileName)
        {
            AlbumFactory abF = new AlbumFactory();
            DatabaseKPopEntities2 db = new DatabaseKPopEntities2();

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var fileUploadImage = HttpContext.Current.Request.Files[0];

                if (fileUploadImage.ContentLength > 0)
                {
                    string imageName = fileUploadImage.FileName;
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageName);
                    string filePath = HttpContext.Current.Server.MapPath("~/Assets/Albums/") + uniqueFileName;

                    fileUploadImage.SaveAs(filePath);

                    Album newAlbum = abF.addAlbum(foreignArtistID, name, description, price, stock, uniqueFileName);

                    db.Albums.Add(newAlbum);
                    db.SaveChanges();

                    return newAlbum;
                }
            }

            // Handle case when no file is uploaded
            return null;
        }


        private string GetApplicationBaseDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (baseDirectory.Contains("bin"))
                baseDirectory = baseDirectory.Substring(0, baseDirectory.LastIndexOf("bin"));

            return baseDirectory;
        }



        public Album updateAlbum(int id, string name, string description, int price, int stock, string fileName)
        {
            Album updateAbm = db.Albums.Find(id);

            updateAbm.AlbumName = name;
            updateAbm.AlbumDescription = description;
            updateAbm.AlbumPrice = price;
            updateAbm.AlbumStock = stock;

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var fileUploadImage = HttpContext.Current.Request.Files[0];

                if (fileUploadImage.ContentLength > 0)
                {
                    string imageName = fileUploadImage.FileName;
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageName);
                    string filePath = HttpContext.Current.Server.MapPath("~/Assets/Albums/") + uniqueFileName;

                    fileUploadImage.SaveAs(filePath);

                    updateAbm.AlbumImage = uniqueFileName;
                }
            }

            db.SaveChanges();

            return updateAbm;
        }

        public Album deleteAlbum(int id)
        {
            Album abm = db.Albums.Find(id);

            var cartAlbum = db.Carts.Where(c => c.AlbumID == id).ToList();

            if (cartAlbum.Count > 0)
            {
                db.Carts.RemoveRange(cartAlbum);
            }

            var transactionDetails = db.TransactionDetails.Where(td => td.AlbumID == id).ToList();
            db.TransactionDetails.RemoveRange(transactionDetails);

            db.Albums.Remove(abm);
            db.SaveChanges();

            return abm;
        }


        public int GetAlbumStock(int albumID)
        {
            int albumStock = 0;

            var album = db.Albums.FirstOrDefault(a => a.AlbumID == albumID);

            if (album != null)
            {
                albumStock = album.AlbumStock;
            }

            return albumStock;
        }


    }
}