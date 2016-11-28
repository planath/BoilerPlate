using System;
using BoilerPlate.Helper;
using BoilerPlate.Model;
using BoilerPlate.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class EventDetailPage : ContentPage
    {
        private IPictureTaker _pictureTaker;

        private EventDetailViewModel Vm => App.Locator.EventDetail;
        public EventDetailPage(Event evnt)
        {
            InitializeComponent();
            _pictureTaker = SimpleIoc.Default.GetInstance<IPictureTaker>();

            Vm.Init(evnt);
            BindingContext = Vm;
            SetBinding(ContentPage.TitleProperty, new Binding("SelectedEvent.Category.Title"));
            this.SetBinding(NavigationPage.BarBackgroundColorProperty, new Binding("SelectedEvent.Category.Color"));

            //TODO: put this code behind for retrieving message into VM
            MessagingCenter.Subscribe<IPictureTaker, string>(this, "pictureTaken", (sender, arg) =>
            {
                Vm.AddPictureCommand.Execute(new Picture(arg));
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
