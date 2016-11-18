using BoilerPlate.Service;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace BoilerPlate.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IPagesMasterService, PagesMasterService>();
            SimpleIoc.Default.Register<IImagesService, ImagesService>();

            SimpleIoc.Default.Register<ClickViewModel>();
            SimpleIoc.Default.Register<GridViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
        }

        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public ClickViewModel Click => ServiceLocator.Current.GetInstance<ClickViewModel>();
        public GridViewModel Grid => ServiceLocator.Current.GetInstance<GridViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}