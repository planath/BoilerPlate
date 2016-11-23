using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class BorderRadiusPage : ContentPage
    {
        private RadiusViewModel Vm => App.Locator.Radius;
        public BorderRadiusPage()
        {
            Vm.Init();
            BindingContext = Vm;
            InitializeComponent();
        }
    }
}
