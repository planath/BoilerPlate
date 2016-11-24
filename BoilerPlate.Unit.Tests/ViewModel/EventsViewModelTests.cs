using System.Collections.Generic;
using System.Linq;
using BoilerPlate.Model;
using BoilerPlate.ViewModel;
using Xunit;

namespace BoilerPlate.Unit.Tests.ViewModel
{
    public class EventsViewModelTests
    {
        private EventsViewModel _vm;

        public EventsViewModelTests()
        {
            _vm = new EventsViewModel();
        }

        [Fact]
        public void AfterInitEventsAreSetUpAndNoFilterDefined()
        {
            _vm.Init();

            Assert.NotEmpty(_vm.Events);
            Assert.Null(_vm.CategoryFilter);
        }

        [Fact]
        public void AfterInitFilteredEventsContainAllEvents()
        {
            _vm.Init();

            Assert.True(_vm.Events.Count >= 0);
        }

        [Fact]
        public void AfterInitCategoriesContainAllCategoriesFromTheDifferentEvents()
        {
            _vm.Init();

            var categories = new List<Category>();
            foreach (var evnt in _vm.Events)
            {
                if (!categories.Contains(evnt.Category))
                {
                    categories.Add(evnt.Category);
                }
            }

            Assert.Equal(_vm.Categories.Count, categories.Count);
        }

        [Fact]
        public void SetCategoryFilter_SelectedCategoryUpdated()
        {
            _vm.Init();
            var category = _vm.Categories.First();
            _vm.SetFilterCommand.Execute(category);
            Assert.Equal(_vm.CategoryFilter, category);
        }

        [Fact]
        public void SetCategoryFilter_FilteredEventsUpdated()
        {
            _vm.Init();
            var initialEventsCount = _vm.Events.Count;
            var category = _vm.Categories.First();
            _vm.SetFilterCommand.Execute(category);

            foreach (var evnt in _vm.Events)
            {
                Assert.Equal(evnt.Category, category);
            }
            Assert.NotEqual(_vm.Events.Count, initialEventsCount);
        }

        [Fact]
        public void SetCategoryFilterTwice_FilteredEventsUpdated()
        {
            _vm.Init();
            var initialEventsCount = _vm.Events.Count;
            var category1 = _vm.Categories.First();
            var category2 = _vm.Categories.Last();
            _vm.SetFilterCommand.Execute(category1);
            _vm.SetFilterCommand.Execute(category2);
            
            foreach (var evnt in _vm.Events)
            {
                Assert.Equal(evnt.Category, category2);
            }
            Assert.NotEqual(_vm.Events.Count, initialEventsCount);
        }

        [Fact]
        public void ResetCategoryFilter_FilteredEventsEqualsAllEvents()
        {
            _vm.Init();
            var initialEventsCount = _vm.Events.Count;
            _vm.SetFilterCommand.Execute(null);

            Assert.Null(_vm.CategoryFilter);
            Assert.Equal(_vm.Events.Count, initialEventsCount);
        }
    }
}
