using System.Collections.Generic;
using BoilerPlate.Model;
using BoilerPlate.Views;

namespace BoilerPlate.Service
{
    public class PagesMasterService : IPagesMasterService
    {
        public IList<PageLink> GetRegistetedLinks()
        {
            return new List<PageLink>
            {
                new PageLink("Click Counter", new ClickPage()),
                new PageLink("Grid - Orientation aware", new GridCsPage()),
                new PageLink("Grid from XAML", new GridXamlPage()),
                new PageLink("Custom iOS Cell", new FancyCellPage()),
                new PageLink("Custom rounded corners View", new BorderRadiusPage())
            };
        }
    }
}
