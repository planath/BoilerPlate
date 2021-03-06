﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void SetCategoryFilter_SelectedCategorysPropertyUpdated()
        {
            _vm.Init();

            var category = _vm.Categories.First();
            _vm.SetFilterCommand.Execute(category);

            Assert.Equal(_vm.CategoryFilter, category);
            Assert.True(_vm.CategoryFilter.Selected);

            foreach (var vmCategory in _vm.Categories)
            {
                if (vmCategory != category)
                {
                    Assert.False(vmCategory.Selected);
                }
            }
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

        [Fact]
        public async void RefreshContent_AllEventsDeletedAndLoadedAgainFromSource()
        {
            _vm.Init();
            var initialEvents = _vm.Events;

            var category = _vm.Categories.Last();
            _vm.SetFilterCommand.Execute(category);
            _vm.RefreshContentCommand.Execute(null);

            // waiting for 2.1 seconds for data to be reloaded
            await Task.Delay(2100);
            var reloadedEvents = _vm.Events;

            foreach (var oldEvent in initialEvents)
            {
                Assert.True(reloadedEvents.Contains(oldEvent));
            }
        }

        [Fact]
        public void ParticipateEvent_PropertyOfEventIsToggeled()
        {
            _vm.Init();
            var initialEvents = _vm.Events;

            var evnt = _vm.Events.Last();
            var evntParticipationBefore = evnt.Participate;
            _vm.ParticipateEventCommand.Execute(evnt);
            var evntParticipationAfter = evnt.Participate;
            
            Assert.False(evntParticipationBefore);
            Assert.True(evntParticipationAfter);
        }
    }
}
