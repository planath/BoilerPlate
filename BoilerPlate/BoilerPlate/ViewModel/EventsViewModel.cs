using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BoilerPlate.Helper;
using BoilerPlate.Model;
using BoilerPlate.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BoilerPlate.ViewModel
{
    public class EventsViewModel : ViewModelBase
    {
        private readonly IEventsService _eventsService;
        private ObservableCollection<Event> _filteredEvents;
        private Category _categoryFilter;
        private bool _isRefreshing;

        public EventsViewModel(IEventsService eventsService)
        {
            _eventsService = eventsService;
            ParticipateEventCommand = new RelayCommand<Event>(ParticipateEvent);
            RefreshContentCommand = new RelayCommand(RefreshContent);
            SetFilterCommand = new RelayCommand<Category>(SetFilter);
        }

        #region Properties
        public RelayCommand<Category> SetFilterCommand { get; set; }
        public RelayCommand<Event> ParticipateEventCommand { get; set; }
        public RelayCommand RefreshContentCommand { get; set; }
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

        public bool IsRefreshing {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(nameof(IsRefreshing));
            }
        }
        #endregion

        public void Init()
        {
            IsRefreshing = false;
            Events = _eventsService.GetMockEventsWithParticipatingEventsChecked();
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

        private void ParticipateEvent(Event evnt)
        {
            evnt.Participate = !evnt.Participate;
            if (evnt.Participate)
            {
                _eventsService.addParticipatingEvent(evnt.Id);
            }
            else
            {
                _eventsService.removeParticipatingEvent(evnt.Id);
            }
        }

        // reloads all data
        private async void RefreshContent()
        {
            await WaitForSeconds(2);

            Events.Remove(e => true);
            foreach (var evnt in _eventsService.GetMockEventsAndReset())
            {
                Events.Add(evnt);
            }
            
            CategoryFilter = null;
            IsRefreshing = false;
        }

        private static async Task WaitForSeconds(double seconds)
        {
            await Task.Factory.StartNew(() => { });
            await Task.Delay((int)(seconds * 1000));
        }

        private void SetFilter(Category newCategoryFilter)
        {
            if (newCategoryFilter == null) return;
            var oldFilter = CategoryFilter;
            CategoryFilter = newCategoryFilter;

            // reset the filter
            if (oldFilter == newCategoryFilter)
            {
                foreach (var evnt in _eventsService.GetMockEventsWithParticipatingEventsChecked())
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
                foreach (var evnt in _eventsService.GetMockEventsWithParticipatingEventsChecked())
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
        #endregion
    }
}
