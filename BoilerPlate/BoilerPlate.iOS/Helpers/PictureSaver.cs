using System;
using BoilerPlate.Helper;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace BoilerPlate.iOS.Helpers
{
    class PictureSaver : IPictureSaver
    {
        public async void SavePictureToDisk(ImageSource imgSrc, string Id)
        {
            var renderer = imgSrc.GetHandler();
            var photo = await renderer.LoadImageAsync(imgSrc);
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory + "/Pictures", Id + ".jpg");
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
        public string GetPictureFromDisk(string Id)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var url = new NSUrl(new NSString(documentsDirectory + "/Pictures"), true);
            NSError error;
            var pathContent = NSFileManager.DefaultManager.GetDirectoryContent(new NSString(documentsDirectory + "/Pictures"), out error);

            string jpgFilename = System.IO.Path.Combine(documentsDirectory + "/Pictures", Id + ".jpg");
            return jpgFilename;
        }
    }
}