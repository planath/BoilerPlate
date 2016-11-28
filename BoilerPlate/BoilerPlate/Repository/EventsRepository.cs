using System;
using System.Collections.ObjectModel;
using BoilerPlate.Helpers;
using BoilerPlate.Model;
using Xamarin.Forms;

namespace BoilerPlate.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ILocalPersistanceHelper _persistanceHelper;

        public EventsRepository(ILocalPersistanceHelper persistanceHelper)
        {
            _persistanceHelper = persistanceHelper;
        }

        public string GetIdsFromParticipatingEvents()
        {
            return _persistanceHelper.ParticipatingEvents;
        }
        public void SetIdsFromParticipatingEvents(string ids)
        {
            _persistanceHelper.ParticipatingEvents = ids;
        }
        public ObservableCollection<Event> GetMockEvents()
        {
            var categoryFood = new Category("Essen", Color.Green);
            var categorySport = new Category("Sport", Color.Red);
            var categoryFun = new Category("Spass", Color.Teal);
            var categoryRelax = new Category("Relaxing", Color.Navy);
            var categoryParty = new Category("Party", Color.Fuchsia);
            var categoryMandatory = new Category("Obligatorisch", Color.Gray);
            var categoryNatur = new Category("Natur", Color.Olive);
            var categoryFav = new Category("Favoriten", Color.Purple);
            return new ObservableCollection<Event>()
            {
                new Event(1,"Zmorge","In der Mensa", DateTime.UtcNow, categoryFood),
                new Event(2,"Zmittag","In der Mensa", DateTime.UtcNow, categoryFood),
                new Event(3,"Znacht","Im Wald", DateTime.UtcNow, categoryFood),
                new Event(5,"Snowboarden","Beim Berg", DateTime.UtcNow, categorySport),
                new Event(6,"Minigolf","Wir treffen uns beim Parkplatz", DateTime.UtcNow, categorySport),
                new Event(7,"Paintball","Wir treffen uns bei der Lounge", DateTime.UtcNow, categoryFun),
                new Event(8,"Puzzeln","In der Lounge", DateTime.UtcNow, categoryFun),
                new Event(8,"Hot Tube","Entspannung put", DateTime.UtcNow, categoryRelax),
                new Event(8,"Tanzen","Ab auf die Tanzfläche - Salsa Baby", DateTime.UtcNow, categoryParty),
                new Event(8,"Abwaschen","In der Küche", DateTime.UtcNow, categoryMandatory),
                new Event(8,"Wandern","6 Stunden Wanderung auf Piz Maletsch", DateTime.UtcNow, categoryNatur),
                new Event(8,"Favoriten","Was dir wichtig ist", DateTime.UtcNow, categoryFav)
            };
        }
    }
}
