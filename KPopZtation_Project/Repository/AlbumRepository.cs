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

    }
}