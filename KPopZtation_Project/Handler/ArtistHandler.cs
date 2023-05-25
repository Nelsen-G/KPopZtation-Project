using KPopZtation_Project.Model;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Handler
{
    public class ArtistHandler
    {
        private ArtistRepository artistRepository;

        public ArtistHandler()
        {
            artistRepository = new ArtistRepository();
        }

        public bool checkName(String name)
        {
            return artistRepository.checkArtistName(name);
        }

        public string getArtistName(int id)
        {
            Artist artist = artistRepository.selectArtist(id);
            return artist != null ? artist.ArtistName : string.Empty;
        }

        public string getFileName(int id)
        {
            Artist artist = artistRepository.selectArtist(id);
            return artist != null ? artist.ArtistImage : string.Empty;
        }

        public void HandleInsertion(string name, string fileName)
        {
            
            artistRepository.createArtist(name, fileName);
        }

        public void HandleUpdate(int id, string name, string fileName)
        {

            artistRepository.updateArtist(id, name, fileName);
        }



    }
}