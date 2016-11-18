using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoilerPlate.Model
{
    public class PageLink
    {
        public PageLink(string title, ContentPage contentPage)
        {
            Title = title;
            ContentPage = contentPage;
        }

        public override string ToString()
        {
            return Title;
        }

        public string Title { get; }
        public ContentPage ContentPage { get; }
    }
}
