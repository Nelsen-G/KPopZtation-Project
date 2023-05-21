﻿using KPopZtation_Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

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
            string fileName = Path.GetFileName(fileUploadImage.FileName);
            //Validasi Nama
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Artist Name must be Filled";
                return;
            }
            else if (!artistHandler.checkName(name))
            {
                errorMessage = "Artist Name must be Unique";
                return;
            }

            //tidak perlu validasi jika file ada atau tidak, karena sudah mengambil dari database sebelumnya 

            else if (fileName.Length > 0)  //tetapi kalo emang ada, baru dicek
            {
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

            artistHandler.HandleUpdate(id, name, fileName);

        }
    }
}