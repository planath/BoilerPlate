using System;
using BoilerPlate.Helper;
using Xamarin.Forms;
using Xamarin.Media;

namespace BoilerPlate.iOS.Helpers
{
    public class PictureTaker : IPictureTaker
    {
        public async void TakePictureFromFile()
        {
            var picker = new MediaPicker();
            if (!picker.PhotosSupported)
                System.Diagnostics.Debug.WriteLine("No Photos Support!");
            else
            {
                try
                {
                    var mediaFile = await picker.PickPhotoAsync();
                    System.Diagnostics.Debug.WriteLine(mediaFile.Path);
                    MessagingCenter.Send<IPictureTaker, string>(this, "pictureTaken", mediaFile.Path);
                }
                catch (OperationCanceledException)
                {
                    System.Diagnostics.Debug.WriteLine("Canceled");
                }
            }
                
        }
        public async void TakePictureFromCamera()
        {
            var picker = new MediaPicker();
            if (!picker.IsCameraAvailable)
                System.Diagnostics.Debug.WriteLine("No camera!");
            else
            {
                try
                {
                    MediaFile file = await picker.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Name = "imported.jpg",
                        Directory = "tmp"
                    });
                    MessagingCenter.Send<IPictureTaker, string>(this, "pictureTaken", file.Path);

                    System.Diagnostics.Debug.WriteLine(file.Path);
                }
                catch (OperationCanceledException)
                {
                    System.Diagnostics.Debug.WriteLine("Canceled");
                }
            }
            
        }
    }
}