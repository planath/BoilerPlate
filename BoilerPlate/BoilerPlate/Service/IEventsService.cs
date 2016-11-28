using System.Collections.ObjectModel;
using BoilerPlate.Model;

namespace BoilerPlate.Service
{
    public interface IEventsService
    {
        void addParticipatingEvent(int id);
        void removeParticipatingEvent(int id);
        int[] allParticipatingEvents();
        ObservableCollection<Event> GetMockEventsWithParticipatingEventsChecked();
        ObservableCollection<Event> GetMockEventsAndReset();
    }
}