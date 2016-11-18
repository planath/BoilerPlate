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
                new PageLink("Grid from Code", new GridPage()),
                new PageLink("Grid from XAML", new GridPortraitPage())
            };
        }
    }
}
