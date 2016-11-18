using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BoilerPlate.ViewModel;
using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public class GridPage : ContentPage
    {private GridViewModel Vm => App.Locator.Grid;
        private Grid _portraitGrid;
        private Grid _landscapeGrid;

        public GridPage()
        {
            Vm.Init();
            BindingContext = Vm;

            // TODO Custom View for Images in RelativeLayout
            var imageContainers = CreatResponsiveImages();

            #region Build GridLayout

            _portraitGrid = new Grid();
            // three childs horizontaly
            _portraitGrid.Children.Add(imageContainers[0], 0, 2, 0, 1);
            _portraitGrid.Children.Add(imageContainers[1], 2, 4, 0, 1);
            _portraitGrid.Children.Add(imageContainers[2], 4, 6, 0, 1);
            // one long child horizontaly
            _portraitGrid.Children.Add(imageContainers[3], 0, 6, 1, 2);
            // two childs horizontaly
            _portraitGrid.Children.Add(imageContainers[4], 0, 3, 2, 3);
            _portraitGrid.Children.Add(imageContainers[5], 3, 6, 2, 3);
            // one long child horizontaly
            _portraitGrid.Children.Add(new Label() { Text = "NEWS STREAM:", BackgroundColor = Color.Gray }, 0, 6, 3, 4);

            _landscapeGrid = new Grid();
            _landscapeGrid.Children.Add(new Label() { Text = "NEWS STREAM:", BackgroundColor = Color.Gray }, 0, 3, 0, 4);
            _landscapeGrid.Children.Add(imageContainers[6], 3, 5, 0, 2);
            _landscapeGrid.Children.Add(imageContainers[7], 5, 7, 0, 2);
            _landscapeGrid.Children.Add(imageContainers[8], 7, 9, 0, 2);
            _landscapeGrid.Children.Add(imageContainers[9], 3, 6, 2, 4);
            _landscapeGrid.Children.Add(imageContainers[10], 6, 9, 2, 4);

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

        // Todo: Remove from code behind to custom view and ViewModel
        private IList<RelativeLayout> CreatResponsiveImages()
        {
            var responsiveImages = new List<RelativeLayout>();

            var image0 = new Image();
            image0.Aspect = Aspect.AspectFill;
            image0.SetBinding(Image.SourceProperty, new Binding("Picture0.FileName"));
            var image0Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image0Container.Children.Add(image0, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image0Container);

            var image1 = new Image();
            image1.Aspect = Aspect.AspectFill;
            image1.SetBinding(Image.SourceProperty, new Binding("Picture1.FileName"));
            var image1Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image1Container.Children.Add(image1, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image1Container);

            var image2 = new Image();
            image2.Aspect = Aspect.AspectFill;
            image2.SetBinding(Image.SourceProperty, new Binding("Picture2.FileName"));
            var image2Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image2Container.Children.Add(image2, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image2Container);


            var image3 = new Image();
            image3.Aspect = Aspect.AspectFill;
            image3.SetBinding(Image.SourceProperty, new Binding("Picture3.FileName"));
            var image3Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image3Container.Children.Add(image3, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image3Container);


            var image4 = new Image();
            image4.Aspect = Aspect.AspectFill;
            image4.SetBinding(Image.SourceProperty, new Binding("Picture4.FileName"));
            var image4Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image4Container.Children.Add(image4, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image4Container);

            var image5 = new Image();
            image5.Aspect = Aspect.AspectFill;
            image5.SetBinding(Image.SourceProperty, new Binding("Picture5.FileName"));
            var image5Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image5Container.Children.Add(image5, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image5Container);

            var image6 = new Image();
            image6.Aspect = Aspect.AspectFill;
            image6.SetBinding(Image.SourceProperty, new Binding("Picture6.FileName"));
            var image6Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image6Container.Children.Add(image6, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image6Container);

            var image7 = new Image();
            image7.Aspect = Aspect.AspectFill;
            image7.SetBinding(Image.SourceProperty, new Binding("Picture7.FileName"));
            var image7Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image7Container.Children.Add(image7, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image7Container);

            var image8 = new Image();
            image8.Aspect = Aspect.AspectFill;
            image8.SetBinding(Image.SourceProperty, new Binding("Picture8.FileName"));
            var image8Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image8Container.Children.Add(image8, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image8Container);

            var image9 = new Image();
            image9.Aspect = Aspect.AspectFill;
            image9.SetBinding(Image.SourceProperty, new Binding("Picture9.FileName"));
            var image9Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image9Container.Children.Add(image9, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image9Container);

            var image10 = new Image();
            image10.Aspect = Aspect.AspectFill;
            image10.SetBinding(Image.SourceProperty, new Binding("Picture10.FileName"));
            var image10Container = new RelativeLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            image10Container.Children.Add(image10, Constraint.Constant(0), Constraint.Constant(0), Constraint.RelativeToParent(p => p.Width), Constraint.RelativeToParent(p => p.Height));
            responsiveImages.Add(image10Container);

            return responsiveImages;
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
