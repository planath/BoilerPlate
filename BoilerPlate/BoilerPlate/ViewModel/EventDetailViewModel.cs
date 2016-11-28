using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BoilerPlate.Helper;
using BoilerPlate.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BoilerPlate.ViewModel
{
    public class EventDetailViewModel : ViewModelBase
    {
        private readonly IPictureSaver _pictureSaver;
        private Event _selectedEvent;
        private ObservableCollection<Picture> _pictures = new ObservableCollection<Picture>();

        public EventDetailViewModel(IPictureSaver pictureSaver)
        {
            _pictureSaver = pictureSaver;
            AddPictureCommand = new RelayCommand<Picture>(AddPicture);
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
        public ObservableCollection<Picture> Pictures
        {
            get { return _pictures; }
            set
            {
                _pictures = value;
                RaisePropertyChanged(nameof(Pictures));
            }
        }

        public RelayCommand<Picture> AddPictureCommand { get; set; }
        #endregion
        public void Init(Event evnt)
        {
            SelectedEvent = evnt;
            if (Pictures.Count <= 0)
            {
                Pictures.Add(new Picture("pictureDefault"));

                var imageSourceLocation = _pictureSaver.GetPictureFromDisk("2");
                Pictures.Add(new Picture(imageSourceLocation));
            }
        }

        #region private methods
        private void AddPicture(Picture picture)
        {
            // Remove placeholder
            if (Pictures.Count == 1)
            {
                if (Pictures.First().FileName.Equals("pictureDefault"))
                {
                    Pictures.RemoveAt(0);
                }
            }

            // persist
            if (picture.ImageSource != null)
            {
                var fileId = SelectedEvent.Id.ToString(); //picture.FileName + 
                _pictureSaver.SavePictureToDisk(picture.ImageSource, fileId);
            }

            // add to view
            Pictures.Add(picture);
        }
        #endregion
    }
}
