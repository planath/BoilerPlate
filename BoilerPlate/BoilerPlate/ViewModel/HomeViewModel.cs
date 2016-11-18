using System.Collections.Generic;
using BoilerPlate.Model;
using BoilerPlate.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BoilerPlate.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IPagesMasterService _pagesMasterService;
        private bool _menuPresented;

        public HomeViewModel(IPagesMasterService pagesMasterService)
        {
            _pagesMasterService = pagesMasterService;
            MenuCloseCommand = new RelayCommand(MenuClose);
        }

        public IList<PageLink> PageLinks { get; set; }
        public bool MenuPresented { get { return _menuPresented; } set { _menuPresented = value; RaisePropertyChanged(nameof(MenuPresented)); } }
        public RelayCommand MenuCloseCommand { get; set; }

        public void MenuClose()
        {
            MenuPresented = true;
            MenuPresented = false;
        }

        public void Init()
        {
            PageLinks = _pagesMasterService.GetRegistetedLinks();
            MenuPresented = true;
        }
    }
}
