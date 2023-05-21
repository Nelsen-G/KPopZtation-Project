using KPopZtation_Project.Factory;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class ArtistRepository
    {

        dbKPopEntities db = dbSingleton.getInstance();

        public bool checkArtistName(String name)
        {
            return !db.Artists.Any(a => a.ArtistName == name);
        }

        public Artist createArtist(String name, String fileName)
        {
            ArtistFactory af = new ArtistFactory();

            Artist newArtist = af.addArtist(name, fileName);

            db.Artists.Add(newArtist);
            db.SaveChanges();

            return newArtist;
        }

        public Artist selectArtist(int artistNumber)
        {
             return db.Artists.FirstOrDefault(a => a.ArtistID == artistNumber);
        }


        public Artist updateArtist(int id, string name, string fileName)
        {
            Artist updateA = new Artist();
            updateA = db.Artists.Find(id);

            updateA.ArtistName = name;
            updateA.ArtistImage = fileName;

            db.SaveChanges();

            return updateA;
        }

        public Artist deleteArtist(int id)
        {
            Artist a = db.Artists.Find(id);
            db.Artists.Remove(a);
            db.SaveChanges();

            return a;
        }

        public List<Artist> getAllArtists()
        {
            return (from a in db.Artists select a).ToList();
        }


       
    }
}