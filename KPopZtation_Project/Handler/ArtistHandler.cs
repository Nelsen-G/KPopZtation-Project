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