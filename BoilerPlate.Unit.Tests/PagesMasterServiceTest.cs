using BoilerPlate.Service;
using Xunit;

namespace BoilerPlate.Unit.Tests
{
    public class PagesMasterServiceTest
    {
        private PagesMasterService _pagesMasterService;

        public PagesMasterServiceTest()
        {
            _pagesMasterService = new PagesMasterService();
        }

        [Fact]
        public void GetRegistetedLinks_AllLinksArePointingToInstancciatedPage()
        {
            var allPages = _pagesMasterService.GetRegistetedLinks();
            foreach (var pageLink in allPages)
            {
                Assert.NotNull(pageLink.ContentPage.Content);
            }
        }

        [Fact]
        public void GetRegistetedLinks_AllLinksHaveADefinedTitle()
        {
            var allPages = _pagesMasterService.GetRegistetedLinks();
            foreach (var pageLink in allPages)
            {
                Assert.False(string.IsNullOrEmpty(pageLink.Title));
            }
        }
    }
}
