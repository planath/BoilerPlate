using System.Collections.ObjectModel;
using BoilerPlate.Model;

namespace BoilerPlate.Repository
{
    public interface IEventsRepository
    {
        string GetIdsFromParticipatingEvents();
        void SetIdsFromParticipatingEvents(string ids);
        ObservableCollection<Event> GetMockEvents();
    }
}