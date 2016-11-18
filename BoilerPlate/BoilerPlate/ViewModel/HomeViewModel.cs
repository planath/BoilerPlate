using System.Collections.Generic;
using BoilerPlate.Model;
using BoilerPlate.Service;
using GalaSoft.MvvmLight;

namespace BoilerPlate.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IPagesMasterService _pagesMasterService;
        private bool _menuPresented;
        private PageLink _selectedItem;

        public HomeViewModel(IPagesMasterService pagesMasterService)
        {
            _pagesMasterService = pagesMasterService;
        }

        public IList<PageLink> PageLinks { get; set; }
        public bool MenuStartMode { get { return _menuPresented; }
            set {
                _menuPresented = value;
                RaisePropertyChanged(nameof(MenuStartMode));
            }
        }

        public void Init()
        {
            PageLinks = _pagesMasterService.GetRegistetedLinks();
            MenuStartMode = true;
        }
    }
}
