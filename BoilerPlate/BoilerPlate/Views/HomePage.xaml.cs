using BoilerPlate.Helper;
using BoilerPlate.Model;
using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class HomePage : MasterDetailPage
    {
        private HomeViewModel Vm => App.Locator.Home;
        public HomePage()
        {
            InitializeComponent();
            Vm.Init();
            BindingContext = Vm;
            SetBinding(IsPresentedProperty, new Binding("MenuStartMode"));
            
            MessagingCenter.Subscribe<INotifyService, string[]>(this, "sentNotification", (sender, arg) =>
            {
                DisplayAlert(arg[0], arg[1], "OK");
            });
        }


        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is PageLink)
            {
                var link = e.SelectedItem as PageLink;
                Detail = new NavigationPage(link.ContentPage);
                ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
