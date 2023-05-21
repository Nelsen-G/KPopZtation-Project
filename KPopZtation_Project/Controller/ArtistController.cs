using KPopZtation_Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using KPopZtation_Project.Model;

namespace KPopZtation_Project.Controller
{
    public class ArtistController
    {

        private ArtistHandler artistHandler;

        public ArtistController()
        {
            artistHandler = new ArtistHandler();
        }

        
        public void validateInsertion(string name, FileUpload fileUploadImage, out string errorMessage)
        {
            errorMessage = string.Empty;
            string fileName = Path.GetFileName(fileUploadImage.FileName);
            //Validasi Nama
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Artist Name must be Filled";
                return;
            } else if (!artistHandler.checkName(name))
            {
                errorMessage = "Artist Name must be Unique";
                return;
            } 
            
            else if (fileName.Length == 0) //Validasi Upload Image
            {
                errorMessage = "Please choose an image file";
                return;

            } else if (fileName.Length > 0) {
                // Validasi extension dari file
                
                string fileExtension = Path.GetExtension(fileUploadImage.FileName).ToLower();
                string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };

                if (!allowedExtensions.Contains(fileExtension))
                {
                    errorMessage = "File extension must be .png, .jpg, .jpeg, or .jfif.";
                    return;
                }

                // Validasi size dari file
                int fileSize = fileUploadImage.PostedFile.ContentLength;
                int maxSizeInBytes = 2 * 1024 * 1024; // ini hasilnya equals to 2MB

                if (fileSize > maxSizeInBytes)
                {
                    errorMessage = "File size must be lower than 2MB";
                    return;
                }

              
            } 
            
            artistHandler.HandleInsertion(name, fileName);
      
        }


        public void validateUpdate(int id, string name, FileUpload fileUploadImage, out string errorMessage)
        {
            errorMessage = string.Empty;
            string fileName = null;

            // Validasi Nama
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Artist Name must be filled";
                return;
            }


            string previousName = artistHandler.getArtistName(id);
            if (!name.Equals(previousName, StringComparison.OrdinalIgnoreCase))
            {
                // kalo diganti namanya, baru cek
                if (!artistHandler.checkName(name))
                {
                    errorMessage = "Artist Name must be unique";
                    return;
                }

            } else
            {
                name = previousName;
            }


            // Cek apakah ada file yang diupload
            if (fileUploadImage.HasFile)
            {
                // Validasi file
                string fileExtension = Path.GetExtension(fileUploadImage.FileName).ToLower();
                string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".jfif" };

                if (!allowedExtensions.Contains(fileExtension))
                {
                    errorMessage = "File extension must be .png, .jpg, .jpeg, or .jfif.";
                    return;
                }

                int maxSizeInBytes = 2 * 1024 * 1024; // 2MB
                if (fileUploadImage.PostedFile.ContentLength > maxSizeInBytes)
                {
                    errorMessage = "File size must be lower than 2MB";
                    return;
                }


                fileName = Path.GetFileName(fileUploadImage.FileName); // kalo ada baru, ganti jadi baru

            }
            else
            {
                fileName = artistHandler.getFileName(id); // kalo gak diupdate, dia bakal pake file name sebelumnya
            }

            artistHandler.HandleUpdate(id, name, fileName);
        }




    }
}