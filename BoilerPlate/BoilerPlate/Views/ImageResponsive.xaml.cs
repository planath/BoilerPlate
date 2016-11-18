using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class ImageResponsive : ContentView
    {
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ImageSource", typeof(string), typeof(ImageResponsive), "", propertyChanged: OnImageSourceChanged);
        
        protected static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ImageResponsive)bindable).OnImageSourceChanged((string)oldValue, (string)newValue);
        }
        public void OnImageSourceChanged(string oldValue, string newValue)
        {
            ImageToBeResponsive.Source = newValue;
        }
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        
        public ImageResponsive()
        {
            InitializeComponent();
        }
    }
}
