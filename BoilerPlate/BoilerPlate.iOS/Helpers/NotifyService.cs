﻿using System;
using BoilerPlate.Helper;
using Foundation;
using UIKit;

namespace BoilerPlate.iOS.Helpers
{
    class NotifyService : INotifyService
    {
        public void Remind(DateTime dateTime, string title, string message)
        {
            var notification = new UILocalNotification();

            //---- set the fire date (the date time in which it will fire)
            //notification.FireDate = (NSDate) dateTime;
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(60);

            //---- configure the alert stuff
            notification.AlertAction = title;
            notification.AlertBody = message;

            //---- modify the badge
            notification.ApplicationIconBadgeNumber = 1;

            //---- set the sound to be the default sound
            notification.SoundName = UILocalNotification.DefaultSoundName;

            //---- schedule it
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}
