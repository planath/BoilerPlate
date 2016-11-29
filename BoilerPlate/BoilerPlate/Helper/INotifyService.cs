using System;

namespace BoilerPlate.Helper
{
    public interface INotifyService
    {
        void Remind(DateTime dateTime, string title, string message);
    }
}
