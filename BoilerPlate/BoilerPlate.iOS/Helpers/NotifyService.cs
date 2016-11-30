using System;
using System.Collections.Generic;
using System.Linq;
using BoilerPlate.Helper;
using BoilerPlate.Model;
using Foundation;
using UIKit;
using UserNotifications;

namespace BoilerPlate.iOS.Helpers
{
    public class NotifyService : INotifyService
    {
        private IDictionary<Event, object> _notifications = new Dictionary<Event, object>();
        public IDictionary<Event, object> Notifications { get { return _notifications; } set { _notifications = value; } }
        public int OnDue { get {return Notifications.Keys.Where(e => e.DateTime < DateTime.Now).Count(); } }
        public void AddNotification(Event participatingEvent)
        {
            AskForNotificationPermission();
            SetUpNotification(participatingEvent);
        }
        public void RemoveNotification(Event participatingEvent)
        {
            var eventPresentInNotifications = Notifications.Keys.FirstOrDefault(e => e.Id == participatingEvent.Id);
            if (eventPresentInNotifications != null)
            {
                var notificationToCancle = Notifications[eventPresentInNotifications] as UILocalNotification;
                UIApplication.SharedApplication.CancelLocalNotification(notificationToCancle);
                Notifications.Remove(eventPresentInNotifications);
            }
        }

        private void SetUpNotification(Event participatingEvent)
        {
            var eventPresentInNotifications = Notifications.Keys.FirstOrDefault(e => e.Id == participatingEvent.Id);
            
            if (eventPresentInNotifications == null)
            {
                CreateNewNotification(participatingEvent);
            }
            else if(eventPresentInNotifications.DateTime != participatingEvent.DateTime)
            {
                UpdateDateTimeOfPresentNotification(participatingEvent, eventPresentInNotifications);
            }
        }

        private void CreateNewNotification(Event participatingEvent)
        {
            var notification = new UILocalNotification();
            notification.FireDate = (NSDate)participatingEvent.DateTime;
            notification.AlertAction = participatingEvent.Title;
            notification.AlertBody = $"Der Event {participatingEvent.Title} startet.";
            notification.SoundName = UILocalNotification.DefaultSoundName;
            var howManyEventsAreYouLateTo = OnDue;
            notification.ApplicationIconBadgeNumber = howManyEventsAreYouLateTo;

            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
            Notifications.Add(participatingEvent, notification);
        }

        private void UpdateDateTimeOfPresentNotification(Event participatingEvent, Event eventPresentInNotifications)
        {
            var notificationToCancle = Notifications[eventPresentInNotifications] as UILocalNotification;
            UIApplication.SharedApplication.CancelLocalNotification(notificationToCancle);
            Notifications.Remove(eventPresentInNotifications);

            SetUpNotification(participatingEvent);
        }
        
        private void AskForNotificationPermission()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var settings =
                    UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (granted, error) =>
                {
                    if (granted)
                    {
                        Console.WriteLine("Granted");

                        var settings =
                            UIUserNotificationSettings.GetSettingsForTypes(
                                UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
                        UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
                    }
                    if (error != null)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                });
            }
            else
            {
                UIApplication.SharedApplication
                    .RegisterForRemoteNotificationTypes(UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge);
            }
        }

    }
}
