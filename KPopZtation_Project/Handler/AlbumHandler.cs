using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Handler
{
    public class AlbumHandler
    {

        private AlbumRepository albumRepository;

        public AlbumHandler()
        {
            albumRepository = new AlbumRepository();
        }

        public void HandleInsertion(int foreignArtistID, string name, string description, int price, int stock, string fileName)
        {

            albumRepository.createAlbum(foreignArtistID, name, description, price, stock, fileName);
        }


    }
}