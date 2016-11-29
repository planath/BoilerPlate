using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.Graphics;
using BoilerPlate.Helper;
using Xamarin.Forms;

namespace BoilerPlate.Droid.Helpers
{
    public class PictureSaver : IPictureSaver
    {
        public void SavePictureToDisk(ImageSource imgSrc, string Id)
        {
            var renderer = imgSrc.GetHandler();
            var photo = renderer.LoadImageAsync(imgSrc, Forms.Context);
            var documentsDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, Id + ".png");
            
            var stream = new FileStream(jpgFilename, FileMode.Create);
            photo.Result.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Close();
        }

        public IEnumerable<string> GetPicturesFromDisk(string id)
        {
            var documentsDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            
            var pathContent = Directory.EnumerateFiles(documentsDirectory);

            var fileNames = pathContent.Where(s => s.Contains(id)).ToList();
            var jpgFileLocations = fileNames.Select(s => System.IO.Path.Combine(documentsDirectory, s));

            return jpgFileLocations;
        }

        public void RemoveAllPictures(string id)
        {

            var documentsDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var pathContent = Directory.EnumerateFiles(documentsDirectory);

            var fileNames = pathContent.Where(s => s.Contains(id)).ToList();
            var jpgFileLocations = fileNames.Select(s => System.IO.Path.Combine(documentsDirectory, s));

            foreach (var jpgFileLocation in jpgFileLocations)
            {
                File.Delete(jpgFileLocation);
            }
        }
    }
}