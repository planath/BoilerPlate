using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class GridXamlPage : ContentPage
    {
        private GridViewModel Vm => App.Locator.Grid;
        public GridXamlPage()
        {
            Vm.Init();
            BindingContext = Vm;
            InitializeComponent();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                var gridBounds = GridWrapper.Bounds;
                gridBounds.Width = Width;
                gridBounds.Height = Width;
                GridWrapper.LayoutTo(gridBounds, 250, Easing.SinInOut);
            }
            else
            {
                var gridBounds = GridWrapper.Bounds;
                gridBounds.Width = Width;
                gridBounds.Height = Width;
                GridWrapper.LayoutTo(gridBounds, 250, Easing.SinInOut);
            }
        }
    }
}
