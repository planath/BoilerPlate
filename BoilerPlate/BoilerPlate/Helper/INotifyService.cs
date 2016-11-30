using System;
using System.Collections.Generic;

namespace BoilerPlate.Helper
{
    public interface INotifyService
    {
        /// <summary>
        /// int identifier to remove notification later, title and message to show with notification and
        /// the time when it should be triggered.
        /// </summary>
        void AddNotification(int identifier, string title, string message, DateTime scheduledDateTime);
        /// <summary>
        /// remove notification by its identifier.
        /// </summary>
        void RemoveNotification(int identifier);
    }
}
