using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BoilerPlate.Helper;
using BoilerPlate.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BoilerPlate.ViewModel
{
    public class EventsViewModel : ViewModelBase
    {
        private ObservableCollection<Event> _filteredEvents;
        private Category _categoryFilter;

        public EventsViewModel()
        {
            SetFilterCommand = new RelayCommand<Category>(SetFilter);
        }

        #region Properties
        public RelayCommand<Category> SetFilterCommand { get; set; }
        public List<Category> Categories { get; set; }
        public Category CategoryFilter
        {
            get { return _categoryFilter; }
            set
            {
                _categoryFilter = value;
                RaisePropertyChanged(nameof(CategoryFilter));
            }
        }
        public ObservableCollection<Event> Events
        {
            get { return _filteredEvents; }
            set
            {
                _filteredEvents = value;
                RaisePropertyChanged(nameof(Events));
            }
        }
        #endregion

        public void Init()
        {
            Events = GetMockEvents();
            CategoryFilter = null;
            Categories = new List<Category>();
            foreach (var evnt in Events)
            {
                if (!Categories.ToList().Contains(evnt.Category))
                {
                    Categories.Add(evnt.Category);
                }
            }
        }

        #region Private functions
        private void SetFilter(Category newCategoryFilter)
        {
            if (newCategoryFilter == null) return;
            var oldFilter = CategoryFilter;
            CategoryFilter = newCategoryFilter;

            // reset the filter
            if (oldFilter == newCategoryFilter)
            {
                foreach (var evnt in GetMockEvents())
                {
                    var alreadyExists = Events.FirstOrDefault(e => e.Title == evnt.Title);
                    if (alreadyExists == null)
                    {
                        Events.Add(evnt);
                    }
                }
                CategoryFilter = null;
            }
            // update from filter
            else
            {
                // remove unwanted
                Events.Remove(e => !e.Category.Title.Equals(newCategoryFilter.Title));

                // add from repo if not already present
                foreach (var evnt in GetMockEvents())
                {
                    if (evnt.Category.Title.Equals(newCategoryFilter.Title))
                    {
                        var alreadyExists = Events.FirstOrDefault(e => e.Title == evnt.Title);
                        if (alreadyExists == null)
                        {
                            Events.Add(evnt);
                        }
                    }
                }
            }
        }

        //Todo: replace with a service class
        private ObservableCollection<Event> GetMockEvents()
        {
            var categoryFood = new Category("Essen", Color.Green);
            var categorySport = new Category("Sport", Color.Red);
            var categoryFun = new Category("Spass", Color.Teal);
            return new ObservableCollection<Event>()
            {
                new Event("Zmorge","In der Mensa", DateTime.UtcNow, categoryFood),
                new Event("Zmittag","In der Mensa", DateTime.UtcNow, categoryFood),
                new Event("Znacht","Im Wald", DateTime.UtcNow, categoryFood),
                new Event("Snowboarden","Beim Berg", DateTime.UtcNow, categorySport),
                new Event("Minigolf","Wir treffen uns beim Parkplatz", DateTime.UtcNow, categorySport),
                new Event("Paintball","Wir treffen uns bei der Lounge", DateTime.UtcNow, categoryFun),
                new Event("Puzzeln","In der Lounge", DateTime.UtcNow, categoryFun),
            };
        }
        #endregion
    }
}
