using KPopZtation_Project.Model;
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

        public static List<Album> GetAlbums()
        {
            return AlbumRepository.GetAlbumsFromRepo();
        }

        public string getFileName(int id)
        {
            Album album = albumRepository.selectAlbum(id);
            return album != null ? album.AlbumImage : string.Empty;
        }

        public void HandleInsertion(int foreignArtistID, string name, string description, int price, int stock, string fileName)
        {

            albumRepository.createAlbum(foreignArtistID, name, description, price, stock, fileName);
        }

        public void HandleUpdate(int id, string name, string description, int price, int stock, string fileName)
        {
            albumRepository.updateAlbum(id, name, description, price, stock, fileName);
        }

    }
}