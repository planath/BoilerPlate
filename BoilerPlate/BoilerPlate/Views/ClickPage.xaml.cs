using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class ClickPage : ContentPage
    {
        private ClickViewModel Vm => App.Locator.Click;
        public ClickPage()
        {
            InitializeComponent();
            Vm.Init();
            BindingContext = Vm;
        }

    }
}
