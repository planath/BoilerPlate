using BoilerPlate.Model;
using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class FancyCellPage : ContentPage
    {
        private GridViewModel Vm => App.Locator.Grid;
        public FancyCellPage()
        {
            Vm.Init();
            BindingContext = Vm;
            InitializeComponent();
            listView.SetBinding(ListView.ItemsSourceProperty, new Binding("Pictures"));
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayAlert("Item Selected", (e.SelectedItem as Picture).FileName, "Ok");
        }
    }
}
