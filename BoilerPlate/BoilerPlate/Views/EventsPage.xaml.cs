using System;
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
            InitializeComponent();
            Vm.Init();
            BindingContext = Vm;
        }
    }
}
