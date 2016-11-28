using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using BoilerPlate.Helper;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using Xamarin.Media;

namespace BoilerPlate.Droid
{
    [Activity(Label = "BoilerPlate", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            SimpleIoc.Default.Register<IPictureTaker, PictureTaker>();

            LoadApplication(new App());
        }
        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled) return;

            var mediaFile = await data.GetMediaFileExtraAsync(Forms.Context);
            System.Diagnostics.Debug.WriteLine(mediaFile.Path);

            MessagingCenter.Send<IPictureTaker, string>(new PictureTaker(), "pictureTaken", mediaFile.Path);
        }
    }
}

