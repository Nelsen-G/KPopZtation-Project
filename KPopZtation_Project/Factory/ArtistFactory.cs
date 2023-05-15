using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Factory
{
    public class ArtistFactory
    {
        public static Artist addArtist(String name, String image)
        {
            Artist newArtist = new Artist();
            newArtist.ArtistName = name;
            newArtist.ArtistImage = image;

            return newArtist;
        }
    }
}