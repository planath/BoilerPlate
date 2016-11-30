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
                new Event(1,"Zmorge","In der Mensa", DateTime.Now.AddSeconds(40), categoryFood),
                new Event(2,"Zmittag","In der Mensa", DateTime.Now.AddSeconds(60), categoryFood),
                new Event(3,"Znacht","Im Wald", DateTime.Now.AddMinutes(2), categoryFood),
                new Event(5,"Snowboarden","Beim Berg", DateTime.Now.AddMinutes(3), categorySport),
                new Event(6,"Minigolf","Wir treffen uns beim Parkplatz", DateTime.Now.AddMinutes(4), categorySport),
                new Event(7,"Paintball","Wir treffen uns bei der Lounge", DateTime.Now.AddMinutes(5), categoryFun),
                new Event(8,"Puzzeln","In der Lounge", DateTime.Now.AddMinutes(6), categoryFun),
                new Event(9,"Hot Tube","Entspannung put", DateTime.Now.AddSeconds(7), categoryRelax),
                new Event(10,"Tanzen","Ab auf die Tanzfläche - Salsa Baby", DateTime.Now.AddMinutes(8), categoryParty),
                new Event(11,"Abwaschen","In der Küche", DateTime.Now, categoryMandatory),
                new Event(12,"Wandern","6 Stunden Wanderung auf Piz Maletsch", DateTime.Now.AddDays(2), categoryNatur),
                new Event(13,"Favoriten","Was dir wichtig ist", DateTime.Now.AddDays(1), categoryFav)
            };
        }
    }
}
