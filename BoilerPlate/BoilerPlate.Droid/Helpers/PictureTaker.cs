using System;
using Android.App;
using BoilerPlate.Helper;
using Xamarin.Forms;
using Xamarin.Media;

namespace BoilerPlate.Droid
{
    public class PictureTaker : IPictureTaker
    {
        public void TakePictureFromCamera()
        {
            var applicationContext = Forms.Context as Activity;
            var picker = new MediaPicker(applicationContext);
            var intent = picker.GetTakePhotoUI(new StoreCameraMediaOptions
            {
                Name = "test.jpg",
                Directory = "AndreasBilder"
            });

            applicationContext.StartActivityForResult(intent, 1);
        }

        public void TakePictureFromFile()
        {
            var applicationContext = Forms.Context as Activity;
            var picker = new MediaPicker(applicationContext);
            var intent = picker.GetPickPhotoUI();

            applicationContext.StartActivityForResult(intent, 1);
        }
    }
}