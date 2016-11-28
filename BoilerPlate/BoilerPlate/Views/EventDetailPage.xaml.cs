using System;
using BoilerPlate.Helper;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class EventDetailPage : ContentPage
    {
        private IPictureTaker _pictureTaker;

        public EventDetailPage()
        {
            InitializeComponent();
            _pictureTaker = SimpleIoc.Default.GetInstance<IPictureTaker>();
            MessagingCenter.Subscribe<IPictureTaker, string>(this, "pictureTaken", (sender, arg) =>
            {
                takenPicture.Source = ImageSource.FromFile(arg);
            });
        }

        private void PictureFromFile_OnClicked(object sender, EventArgs e)
        {
            _pictureTaker.TakePictureFromFile();
        }
        private void PictureFromCamera_OnClicked(object sender, EventArgs e)
        {
            _pictureTaker.TakePictureFromCamera();
        }
    }
}
