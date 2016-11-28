using System;
using BoilerPlate.Model;
using BoilerPlate.ViewModel;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class EventsPage : ContentPage
    {
        private EventsViewModel Vm => App.Locator.Events;
        public EventsPage()
        {
            FlowListView.Init();
            Vm.Init();
            BindingContext = Vm;
            InitializeComponent();
        }

        private void Events_OnRefreshing(object sender, EventArgs e)
        {
            Vm.RefreshContentCommand.Execute(null);
        }

        private void Events_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            if (item is Event)
            {
                Vm.SelectEventCommand.Execute(item);
                Navigation.PushAsync(new EventDetailPage((Event)item));
            }
            if (sender is ListView)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
