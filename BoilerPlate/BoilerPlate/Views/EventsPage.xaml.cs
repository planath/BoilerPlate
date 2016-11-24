using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class EventsPage : ContentPage
    {
        private EventsViewModel Vm => App.Locator.Events;
        public EventsPage()
        {
            InitializeComponent();
            Vm.Init();
            BindingContext = Vm;
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Vm.SetFilterCommand.Execute(e.SelectedItem);
            FilterList.SelectedItem = null;
        }
    }
}
