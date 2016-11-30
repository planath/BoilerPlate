using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using BoilerPlate.Helper;
using Java.Util;
using Xamarin.Forms;

namespace BoilerPlate.Droid.Helpers
{
    public class NotifyService : INotifyService
    {
        public IDictionary<int, PendingIntent> Notifications { get; } = new Dictionary<int, PendingIntent>();

        public void AddNotification(int identifier, string title, string message, DateTime scheduledDateTime)
        {
            if (Notifications.ContainsKey(identifier))
            {
                RemoveNotification(identifier);
            }

            Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("message", message);
            alarmIntent.PutExtra("title", title);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent,
                PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager) Forms.Context.GetSystemService(Context.AlarmService);

            Calendar calendarScheduled = Calendar.GetInstance(Locale.German);
            calendarScheduled.Set(scheduledDateTime.Year, scheduledDateTime.Month,
                scheduledDateTime.Day, scheduledDateTime.Hour, scheduledDateTime.Minute,
                scheduledDateTime.Second);

            Calendar calendarNow = Calendar.GetInstance(Locale.German);
            var now = DateTime.Now;
            calendarNow.Set(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

            long alertInMillisFromNow = calendarScheduled.TimeInMillis - calendarNow.TimeInMillis;

            if (alertInMillisFromNow > 0)
            {
                alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + alertInMillisFromNow, pendingIntent);
                Notifications.Add(identifier, pendingIntent);
            }
        }

        public void RemoveNotification(int identifier)
        {
            if (Notifications.ContainsKey(identifier))
            {
                var pendingIntent = Notifications[identifier];
                AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
                alarmManager.Cancel(pendingIntent);
                Notifications.Remove(identifier);
            }
        }
    }
}