
using Xamarin.Forms;

namespace BoilerPlate.Model
{
    public class Category
    {
        public Category(string title, Color color)
        {
            Title = title;
            Color = color;
        }

        public string Title { get; internal set; }
        public Color Color { get; internal set; }
        public bool Selected { get; set; }
    }
}
