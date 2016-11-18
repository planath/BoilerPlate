using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public class GridCsPage : ContentPage
    {
        private GridViewModel Vm => App.Locator.Grid;
        private Grid _portraitGrid;
        private Grid _landscapeGrid;

        public GridCsPage()
        {
            Vm.Init();
            BindingContext = Vm;

            #region Build responsive images for the GridLayout
            var image0 = new ImageResponsive();
            image0.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture0.FileName"));

            var image1 = new ImageResponsive();
            image1.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture1.FileName"));

            var image2 = new ImageResponsive();
            image2.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture2.FileName"));

            var image3 = new ImageResponsive();
            image3.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture3.FileName"));

            var image4 = new ImageResponsive();
            image4.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture4.FileName"));

            var image5 = new ImageResponsive();
            image5.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture5.FileName"));

            var image6 = new ImageResponsive();
            image6.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture6.FileName"));

            var image7 = new ImageResponsive();
            image7.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture7.FileName"));

            var image8 = new ImageResponsive();
            image8.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture8.FileName"));

            var image9 = new ImageResponsive();
            image9.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture9.FileName"));

            var image10 = new ImageResponsive();
            image10.SetBinding(ImageResponsive.ImageSourceProperty, new Binding("Picture10.FileName"));
            #endregion

            #region Build GridLayout
            _portraitGrid = new Grid();
            // three childs horizontaly
            _portraitGrid.Children.Add(image0, 0, 2, 0, 1);
            _portraitGrid.Children.Add(image1, 2, 4, 0, 1);
            _portraitGrid.Children.Add(image2, 4, 6, 0, 1);
            // one long child horizontaly
            _portraitGrid.Children.Add(image3, 0, 6, 1, 2);
            // two childs horizontaly
            _portraitGrid.Children.Add(image4, 0, 3, 2, 3);
            _portraitGrid.Children.Add(image5, 3, 6, 2, 3);
            // one long child horizontaly
            _portraitGrid.Children.Add(new Label() { Text = "NEWS STREAM:", BackgroundColor = Color.Gray }, 0, 6, 3, 4);

            _landscapeGrid = new Grid();
            _landscapeGrid.Children.Add(new Label() { Text = "NEWS STREAM:", BackgroundColor = Color.Gray }, 0, 3, 0, 4);
            _landscapeGrid.Children.Add(image6, 3, 5, 0, 2);
            _landscapeGrid.Children.Add(image7, 5, 7, 0, 2);
            _landscapeGrid.Children.Add(image8, 7, 9, 0, 2);
            _landscapeGrid.Children.Add(image9, 3, 6, 2, 4);
            _landscapeGrid.Children.Add(image10, 6, 9, 2, 4);
            #endregion

            if (Height > Width)
            {
                Content = _portraitGrid;
            }
            else
            {
                Content = _landscapeGrid;
            }

        }
        
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            
            if (Height > Width)
            {
                Content = _portraitGrid;
            }
            else
            {
                Content = _landscapeGrid;
            }
        }
    }
}
