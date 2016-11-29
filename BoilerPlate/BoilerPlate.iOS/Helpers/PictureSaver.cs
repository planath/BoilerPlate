using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BoilerPlate.Helper;
using Foundation;
using Xamarin.Forms;

namespace BoilerPlate.iOS.Helpers
{
    class PictureSaver : IPictureSaver
    {
        public async void SavePictureToDisk(ImageSource imgSrc, string Id)
        {
            var renderer = imgSrc.GetHandler();
            var photo = await renderer.LoadImageAsync(imgSrc);
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, Id + ".jpg");
            NSData imgData = photo.AsJPEG();
            NSError err = null;
            if (imgData.Save(jpgFilename, false, out err))
            {
                Console.WriteLine("saved as " + jpgFilename);
            }
            else
            {
                Console.WriteLine("NOT saved as " + jpgFilename + " because" + err.LocalizedDescription);
            }
        }
        public IEnumerable<string> GetPicturesFromDisk(string id)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            NSError error;
            var pathContent = NSFileManager.DefaultManager.GetDirectoryContent(new NSString(documentsDirectory), out error);

            var fileNames = pathContent.Where(s => s.Contains(id)).ToList();
            var jpgFileLocations = fileNames.Select(s => System.IO.Path.Combine(documentsDirectory, s));

            return jpgFileLocations;
        }
        public void RemoveAllPictures(string id)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            NSError error;
            var pathContent = NSFileManager.DefaultManager.GetDirectoryContent(new NSString(documentsDirectory), out error);

            var fileNames = pathContent.Where(s => s.Contains(id)).ToList();
            var jpgFileLocations = fileNames.Select(s => System.IO.Path.Combine(documentsDirectory, s));

            foreach (var jpgFileLocation in jpgFileLocations)
            {
                File.Delete(jpgFileLocation);
            }
        }
    }
}
