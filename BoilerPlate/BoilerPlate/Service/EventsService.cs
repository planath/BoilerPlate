using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Model;
using BoilerPlate.Repository;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BoilerPlate.Service
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public void addParticipatingEvent(int id)
        {
            var newId = new int[]{id};
            
            var savedIds = _eventsRepository.GetIdsFromParticipatingEvents();
            if (savedIds.Equals(String.Empty))
            {
                var ids = JsonConvert.SerializeObject(newId);
                _eventsRepository.SetIdsFromParticipatingEvents(ids);
            }
            else
            {
                var presentIds = JsonConvert.DeserializeObject<int[]>(savedIds);
                var idsToSave = new int[presentIds.Length + 1];

                newId.CopyTo(idsToSave, 0);
                presentIds.CopyTo(idsToSave, 1);

                var newIds = JsonConvert.SerializeObject(idsToSave);
                _eventsRepository.SetIdsFromParticipatingEvents(newIds);
            }
        }

        public void removeParticipatingEvent(int idToRemove)
        {
            var savedIds = _eventsRepository.GetIdsFromParticipatingEvents();
            if (savedIds.Equals(String.Empty)) return;

            var presentIds = JsonConvert.DeserializeObject<int[]>(savedIds);
            if (presentIds.Length <= 1)
            {
                _eventsRepository.SetIdsFromParticipatingEvents(string.Empty);
            }
            else
            {
                var idsToSave = new int[presentIds.Length - 1];

                for (int i = 0; i < (presentIds.Length - 1); i++)
                {
                    if (presentIds[i] != idToRemove)
                    {
                        idsToSave[i] = presentIds[i];
                    }
                }

                var newIds = JsonConvert.SerializeObject(idsToSave);
                _eventsRepository.SetIdsFromParticipatingEvents(newIds);
            }
            
        }

        public int[] allParticipatingEvents()
        {
            var savedIds = _eventsRepository.GetIdsFromParticipatingEvents();
            return JsonConvert.DeserializeObject<int[]>(savedIds);
        }

        public ObservableCollection<Event> GetMockEventsWithParticipatingEventsChecked()
        {
            var idsOfParticipatingEvents = allParticipatingEvents();
            var mockEvents = _eventsRepository.GetMockEvents();

            if (idsOfParticipatingEvents != null)
            {
                foreach (var evnt in mockEvents.Where(e => idsOfParticipatingEvents.Contains(e.Id)))
                    evnt.Participate = true;
            }

            return mockEvents;
        }

        public ObservableCollection<Event> GetMockEventsAndReset()
        {
            _eventsRepository.SetIdsFromParticipatingEvents(String.Empty);
            return _eventsRepository.GetMockEvents();
        }
    }
}
