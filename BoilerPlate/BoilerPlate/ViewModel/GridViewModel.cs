using System.Collections.Generic;
using BoilerPlate.Model;
using BoilerPlate.Service;
using GalaSoft.MvvmLight;

namespace BoilerPlate.ViewModel
{
    public class GridViewModel : ViewModelBase
    {
        private readonly IImagesService _imagesService;

        public GridViewModel(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }
        public IList<Picture> Pictures { get; set; }
        public Picture Picture0 { get; set; }
        public Picture Picture1 { get; set; }
        public Picture Picture2 { get; set; }
        public Picture Picture3 { get; set; }
        public Picture Picture4 { get; set; }
        public Picture Picture5 { get; set; }
        public Picture Picture10 { get; set; }
        public Picture Picture9 { get; set; }
        public Picture Picture8 { get; set; }
        public Picture Picture7 { get; set; }
        public Picture Picture6 { get; set; }

        public void Init()
        {
            Pictures = _imagesService.GetPictures();
            Picture0 = Pictures[0];
            Picture1 = Pictures[1];
            Picture2 = Pictures[2];
            Picture3 = Pictures[3];
            Picture4 = Pictures[4];
            Picture5 = Pictures[5];
            Picture6 = Pictures[6];
            Picture7 = Pictures[7];
            Picture8 = Pictures[8];
            Picture9 = Pictures[9];
            Picture10 = Pictures[10];
        }
    }
}
