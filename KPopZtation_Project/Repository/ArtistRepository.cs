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



       
    }
}