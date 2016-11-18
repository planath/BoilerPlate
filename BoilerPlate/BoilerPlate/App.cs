using BoilerPlate.ViewModel;
using BoilerPlate.Views;
using Xamarin.Forms;

namespace BoilerPlate
{
    public class App : Application
    {
        private static ViewModelLocator _locator;
        public App()
        {
            MainPage = GetInitialPage();
        }
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());
        public static Page GetInitialPage()
        {
            return new HomePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
