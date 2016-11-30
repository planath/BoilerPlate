using System;
using System.Collections.Generic;
using BoilerPlate.Model;

namespace BoilerPlate.Helper
{
    public interface INotifyService
    {
        IDictionary<Event, object> Notifications { get; set; }
        int OnDue { get; }
        void AddNotification(Event participatingEvent);
        void RemoveNotification(Event participatingEvent);
    }
}
