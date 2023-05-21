using KPopZtation_Project.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

namespace KPopZtation_Project.Controller
{
    public class AlbumController
    {

        private AlbumHandler albumHandler;

        public AlbumController()
        {
            albumHandler = new AlbumHandler();
        }


        public void validateInsertAlbum(string name, string description, string priceText, string stockText, FileUpload fileUploadImage, out string errorMessage, string artistID)
        {
            errorMessage = string.Empty;
            string fileName = Path.GetFileName(fileUploadImage.FileName);

            int price;
            int stock;

            // Validate required fields
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Name must be filled.";
                return;
            }
            else if (name.Length > 50)
            {
                errorMessage = "Name must be smaller than 50 characters.";
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                errorMessage = "Description must be filled.";
                return;
            } else if (description.Length > 255)
            {
                errorMessage = "Description must be smaller than 255 characters.";
                return;
            }

            if (!int.TryParse(priceText, out price))
            {
                errorMessage = "Price must be a valid number.";
                return;
            }
            else if (price < 100000 || price > 1000000)
            {
                errorMessage = "Price must be between 100000 and 1000000.";
                return;
            }

            if (!int.TryParse(stockText, out stock))
            {
                errorMessage = "Stock must be a valid number.";
                return;
            }
            else if (stock <= 0)
            {
                errorMessage = "Stock must be greater than 0.";
                return;
            }


            if (fileName.Length == 0) //Validasi Upload Image
            {
                errorMessage = "Please choose an image file";
                return;

            }
            else if (fileName.Length > 0)
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

            int foreignArtistID = Convert.ToInt32(artistID);

            albumHandler.HandleInsertion(foreignArtistID, name, description, price, stock, fileName);

        }

    }
}