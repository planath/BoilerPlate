using System.Linq;
using BoilerPlate.Helper;
using BoilerPlate.Model;
using BoilerPlate.Repository;
using BoilerPlate.Service;
using BoilerPlate.ViewModel;
using Xunit;

namespace BoilerPlate.Unit.Tests.ViewModel
{
    public class EventDetailViewModelTests
    {
        private EventDetailViewModel _vm;
        private EventsService _eventsService;

        public EventDetailViewModelTests()
        {
            _vm = new EventDetailViewModel();
            _eventsService = new EventsService(new EventsRepository( new Settings()));
        }

        [Fact]
        public void AfterInitPropertiesForPageAreSetUp()
        {
            _vm.Init();

            // selectedEvent will be provided from its MasterView
            _vm.SelectedEvent = _eventsService.GetMockEventsAndReset().FirstOrDefault();

            Assert.NotEmpty(_vm.SelectedEvent.Title);
            Assert.NotEmpty(_vm.SelectedEvent.Description);
            Assert.NotNull(_vm.SelectedEvent.Participate);
            Assert.NotNull(_vm.SelectedEvent.Category);
            Assert.NotNull(_vm.SelectedEvent.DateTime);

            Assert.NotEmpty(_vm.Pictures);
            Assert.NotNull(_vm.Pictures);
        }

        [Fact]
        public void AfterInitPicturesArePresentOrDefaultPictureIsLoaded()
        {
            _vm.Init();

            Assert.NotEmpty(_vm.Pictures);
        }
    }
}