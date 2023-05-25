using KPopZtation_Project.Factory;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class AlbumRepository
    {

        dbKPopEntities db = dbSingleton.getInstance();

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

        public Album createAlbum(int foreignArtistID, String name, String description, int price, int stock, String fileName)
        {
            AlbumFactory abF = new AlbumFactory();

            Album newAlbum = abF.addAlbum(foreignArtistID, name, description, price, stock, fileName);

            db.Albums.Add(newAlbum);
            db.SaveChanges();

            return newAlbum;


        }

        public Album updateAlbum(int id, string name, string description, int price, int stock, string fileName)
        {
            Album updateAbm = new Album();
            updateAbm = db.Albums.Find(id);

            updateAbm.AlbumName = name;
            updateAbm.AlbumDescription = description;
            updateAbm.AlbumPrice = price;
            updateAbm.AlbumStock = stock;
            updateAbm.AlbumImage = fileName;


            db.SaveChanges();

            return updateAbm;

        }


        public Album deleteAlbum(int id)
        {
            Album abm = db.Albums.Find(id);
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