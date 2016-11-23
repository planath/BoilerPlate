using Xamarin.Forms;

namespace BoilerPlate.Views.Cell
{
    public class FancyCell : ViewCell
    {
        public static readonly BindableProperty TitleProperty =
          BindableProperty.Create("Title", typeof(string), typeof(FancyCell), "");

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty SubTitleProperty =
          BindableProperty.Create("SubTitle", typeof(string), typeof(FancyCell), "");

        public string SubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set { SetValue(SubTitleProperty, value); }
        }

        public static readonly BindableProperty ImageFilenameProperty =
          BindableProperty.Create("ImageFilename", typeof(string), typeof(FancyCell), "");

        public string ImageFilename
        {
            get { return (string)GetValue(ImageFilenameProperty); }
            set { SetValue(ImageFilenameProperty, value); }
        }
    }
}
