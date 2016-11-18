using Xamarin.Forms;

namespace BoilerPlate.Views
{
    public partial class ImageResponsive : ContentView
    {

        #region Bindable Properties
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ImageSource", typeof(string), typeof(ImageResponsive), "", propertyChanged: OnImageSourceChanged);

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion

        public ImageResponsive()
        {
            InitializeComponent();
        }
        public void OnImageSourceChanged(string oldValue, string newValue)
        {
            ImageToBeResponsive.Source = newValue;
        }
        protected static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ImageResponsive)bindable).OnImageSourceChanged((string)oldValue, (string)newValue);
        }
    }
}
