using KPopZtation_Project.Factory;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class ArtistRepository
    {

        DatabaseKPopEntities2 db = dbSingleton.getInstance();

        public bool checkArtistName(String name)
        {
            return !db.Artists.Any(a => a.ArtistName == name);
        }

        public Artist createArtist(string name, string fileName)
        {
            ArtistFactory af = new ArtistFactory();

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var fileUploadImage = HttpContext.Current.Request.Files[0];

                if (fileUploadImage.ContentLength > 0)
                {
                    string imageName = fileUploadImage.FileName;
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageName);
                    string filePath = HttpContext.Current.Server.MapPath("~/Assets/Artists/") + uniqueFileName;

                    fileUploadImage.SaveAs(filePath);

                    Artist newArtist = af.addArtist(name, uniqueFileName);

                    db.Artists.Add(newArtist);
                    db.SaveChanges();

                    return newArtist;
                }
            }
            return null;
        }


        public Artist selectArtist(int artistNumber)
        {
             return db.Artists.FirstOrDefault(a => a.ArtistID == artistNumber);
        }


        public Artist updateArtist(int id, string name, string fileName)
        {
            Artist updateA = db.Artists.Find(id);

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var fileUploadImage = HttpContext.Current.Request.Files[0];

                if (fileUploadImage.ContentLength > 0)
                {
                    string imageName = fileUploadImage.FileName;
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageName);
                    string filePath = HttpContext.Current.Server.MapPath("~/Assets/Artists/") + uniqueFileName;

                    fileUploadImage.SaveAs(filePath);

                    updateA.ArtistImage = uniqueFileName;
                }
            }

            updateA.ArtistName = name;

            db.SaveChanges();

            return updateA;
        }


        public Artist deleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);

            var artistAlbums = db.Albums.Where(a => a.ArtistID == id).ToList();

            foreach (var album in artistAlbums)
            {
                var transactionDetails = db.TransactionDetails.Where(td => td.AlbumID == album.AlbumID).ToList();
                db.TransactionDetails.RemoveRange(transactionDetails);

                db.Albums.Remove(album);
            }

            db.Artists.Remove(artist);
            db.SaveChanges();

            return artist;
        }


        public List<Artist> getAllArtists()
        {
            return (from a in db.Artists select a).ToList();
        }

        public Artist getArtistById(int id)
        {
            return db.Artists.FirstOrDefault(a => a.ArtistID == id);
        }


    }
}