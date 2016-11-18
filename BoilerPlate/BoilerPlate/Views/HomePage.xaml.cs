using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Model;
using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            InitializeComponent();
            Vm.Init();
            BindingContext = Vm;
            SetBinding(IsPresentedProperty, new Binding("MenuPresented"));
        }

        private HomeViewModel Vm => App.Locator.Home;

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //TODO remove code behind and put it to VM
            if (e.SelectedItem is PageLink)
            {
                var link = e.SelectedItem as PageLink;
                Detail = new NavigationPage(link.ContentPage);
                ListView.SelectedItem = null;
                Vm.MenuCloseCommand.Execute("");
            }
        }
    }
}
