using System;
using System.Collections.Generic;
using System.Linq;
using BoilerPlate.Helper;
using Foundation;
using UIKit;
using UserNotifications;

namespace BoilerPlate.iOS.Helpers
{
    public class NotifyService : INotifyService
    {
        public IDictionary<int, UILocalNotification> Notifications { get; } = new Dictionary<int, UILocalNotification>();
        public int OnDue { get {return Notifications.Values.Count(e => (DateTime)e.FireDate < DateTime.Now); } }
        public void AddNotification(int identifier, string title, string message, DateTime scheduledDateTime)
        {
            AskForNotificationPermission();
            SetUpNotification(identifier, title, message, scheduledDateTime);
        }
        public void RemoveNotification(int identifier)
        {
            if (Notifications.ContainsKey(identifier))
            {
                var notificationToCancle = Notifications[identifier];
                UIApplication.SharedApplication.CancelLocalNotification(notificationToCancle);
                Notifications.Remove(identifier);
            }
        }

        private void SetUpNotification(int identifier, string title, string message, DateTime scheduledDateTime)
        {
            if (!Notifications.Keys.Contains(identifier))
            {
                CreateNewNotification(identifier, title, message, scheduledDateTime);
            }
            else if((DateTime)Notifications[identifier].FireDate != scheduledDateTime)
            {
                UpdateDateTimeOfPresentNotification(identifier, title, message, scheduledDateTime);
            }
        }

        private void CreateNewNotification(int identifier, string title, string message, DateTime scheduledDateTime)
        {
            var notification = new UILocalNotification();
            notification.FireDate = (NSDate)scheduledDateTime;
            notification.AlertTitle = title;
            notification.AlertBody = message;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            var howManyEventsAreYouLateTo = OnDue + 1;
            notification.ApplicationIconBadgeNumber = howManyEventsAreYouLateTo;

            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
            Notifications.Add(identifier, notification);
        }

        private void UpdateDateTimeOfPresentNotification(int identifier, string title, string message, DateTime scheduledDateTime)
        {
            RemoveNotification(identifier);
            SetUpNotification(identifier, title, message, scheduledDateTime);
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
