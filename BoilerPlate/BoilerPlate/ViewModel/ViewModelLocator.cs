using BoilerPlate.Helper;
using BoilerPlate.Helpers;
using BoilerPlate.Repository;
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
            SimpleIoc.Default.Register<ILocalPersistanceHelper, Settings>();
            SimpleIoc.Default.Register<IEventsService, EventsService>();
            SimpleIoc.Default.Register<IEventsRepository, EventsRepository>();

            SimpleIoc.Default.Register<ClickViewModel>();
            SimpleIoc.Default.Register<GridViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<RadiusViewModel>();
            SimpleIoc.Default.Register<EventsViewModel>();
        }

        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public ClickViewModel Click => ServiceLocator.Current.GetInstance<ClickViewModel>();
        public GridViewModel Grid => ServiceLocator.Current.GetInstance<GridViewModel>();
        public RadiusViewModel Radius => ServiceLocator.Current.GetInstance<RadiusViewModel>();
        public EventsViewModel Events => ServiceLocator.Current.GetInstance<EventsViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}