using BoilerPlate.Helpers;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BoilerPlate.Helper
{
    public class Settings : ILocalPersistanceHelper
    {
        private const string ParticipatingEventsKey = "partipicate_key";
        private static readonly string ParticipatingEventsDefault = string.Empty;

        public string ParticipatingEvents
        {
            get { return AppSettings.GetValueOrDefault<string>(ParticipatingEventsKey, ParticipatingEventsDefault); }
            set { AppSettings.AddOrUpdateValue<string>(ParticipatingEventsKey, value); }
        }
        
        private ISettings AppSettings => CrossSettings.Current;
    }
}
