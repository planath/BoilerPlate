using System;
using BoilerPlate.Helper;
using BoilerPlate.iOS.Helpers;
using Foundation;
using GalaSoft.MvvmLight.Ioc;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

namespace BoilerPlate.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // DI
            SimpleIoc.Default.Register<IPictureTaker, PictureTaker>();
            SimpleIoc.Default.Register<IPictureSaver, PictureSaver>();
            SimpleIoc.Default.Register<INotifyService, NotifyService>();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // show an alert
            //UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
            //okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            var notifyServiceInstance = SimpleIoc.Default.GetInstance<INotifyService>();
            MessagingCenter.Send<INotifyService, string[]>(notifyServiceInstance, "sentNotification", new string[]{ notification.AlertAction,notification.AlertBody});

            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }
    }
}
