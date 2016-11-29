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

            imageAction.GestureRecognizers.Add(new TapGestureRecognizer(sender => {
                imageAction.Opacity = 0.5;
                imageAction.FadeTo(1);

                // Todo: _pictureTaker servce to VM
                _pictureTaker.TakePictureFromFile();
            }));

            cameraAction.GestureRecognizers.Add(new TapGestureRecognizer(sender => {
                cameraAction.Opacity = 0.5;
                cameraAction.FadeTo(1);

                // Todo: _pictureTaker servce to VM
                _pictureTaker.TakePictureFromCamera();
            }));

            removeAction.GestureRecognizers.Add(new TapGestureRecognizer(sender => {
                removeAction.Opacity = 0.5;
                removeAction.FadeTo(1);

                Vm.ResetPicturesCommand.Execute(null);
            }));
        }
    }
}
