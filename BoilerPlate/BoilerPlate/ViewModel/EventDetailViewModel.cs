using System.Collections.Generic;
using BoilerPlate.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BoilerPlate.ViewModel
{
    public class EventDetailViewModel : ViewModelBase
    {
        private Event _selectedEvent;
        private IList<Picture> _pictures = new List<Picture>();

        public EventDetailViewModel()
        {
            TakePictureCommand = new RelayCommand(TakePicture);
        }

        #region Properties and Commands
        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                RaisePropertyChanged(nameof(SelectedEvent));
            }
        }
        public IList<Picture> Pictures
        {
            get { return _pictures; }
            set
            {
                _pictures = value;
                RaisePropertyChanged(nameof(Pictures));
            }
        }

        public RelayCommand TakePictureCommand { get; set; }
        #endregion
        public void Init()
        {
            if (Pictures.Count <= 0)
            {
                   Pictures.Add(new Picture("pictureDefault"));
            }
        }

        #region private methods
        private void TakePicture()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
