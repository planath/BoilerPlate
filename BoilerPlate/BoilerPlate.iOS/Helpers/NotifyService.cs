using System;
using BoilerPlate.Helper;
using Foundation;
using UIKit;
using UserNotifications;

namespace BoilerPlate.iOS.Helpers
{
    class NotifyService : INotifyService
    {
        public void Remind(DateTime dateTime, string title, string message)
        {
            AskForNotificationPermission();
            SetUpNotification(dateTime, title, message);
        }

        private static void SetUpNotification(DateTime dateTime, string title, string message)
        {
            var notification = new UILocalNotification();
            
            //notification.FireDate = (NSDate) dateTime;
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(8);
            notification.AlertAction = title;
            notification.AlertBody = message;
            notification.SoundName = UILocalNotification.DefaultSoundName;
            // AppBadge not implemented yet
            // notification.ApplicationIconBadgeNumber = 1;
            
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }

        private static void AskForNotificationPermission()
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
