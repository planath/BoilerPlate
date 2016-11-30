using System.Collections.ObjectModel;
using System.Linq;
using BoilerPlate.Helper;
using BoilerPlate.Model;
using BoilerPlate.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace BoilerPlate.ViewModel
{
    public class EventDetailViewModel : ViewModelBase
    {
        private readonly IPictureSaver _pictureSaver;
        private readonly IEventsService _eventsService;
        private readonly INotifyService _notifyService;
        private Event _selectedEvent;
        private ObservableCollection<Picture> _pictures = new ObservableCollection<Picture>();
        private Picture _headerPicture;
        private bool _participate;

        public EventDetailViewModel(IPictureSaver pictureSaver, IEventsService eventsService, INotifyService notifyService)
        {
            _pictureSaver = pictureSaver;
            _eventsService = eventsService;
            _notifyService = notifyService;
            AddPictureCommand = new RelayCommand<Picture>(AddPicture);
            ResetPicturesCommand = new RelayCommand(ResetPictures);

            MessagingCenter.Subscribe<IPictureTaker, string>(this, "pictureTaken", (sender, arg) =>
            {
                AddPictureCommand.Execute(new Picture(arg));
            });
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
        public Picture HeaderPicture
        {
            get { return _headerPicture; }
            set
            {
                _headerPicture = value;
                RaisePropertyChanged(nameof(HeaderPicture));
            }
        }
        public bool Participate
        {
            get { return _participate; }
            set
            {
                _participate = value;
                SelectedEvent.Participate = value;

                if (_participate)
                {
                    _eventsService.addParticipatingEvent(SelectedEvent.Id);
                    _notifyService.AddNotification(SelectedEvent.Id, SelectedEvent.Category.Title, SelectedEvent.Title + " startet jetzt.", SelectedEvent.DateTime);
                }
                else
                {
                    _eventsService.removeParticipatingEvent(SelectedEvent.Id);
                    _notifyService.RemoveNotification(SelectedEvent.Id);
                }
                RaisePropertyChanged(nameof(Participate));
            }
        }

        public RelayCommand<Picture> AddPictureCommand { get; set; }
        public RelayCommand ResetPicturesCommand { get; set; }
        
        #endregion
        public void Init(Event evnt)
        {
            SelectedEvent = evnt;
            Pictures.Remove(p => true);
            Participate = SelectedEvent.Participate;

            var imageSourceLocations = _pictureSaver.GetPicturesFromDisk(SelectedEvent.IdForFileSystem).ToList();
            if (imageSourceLocations.Count >= 1)
            {
                HeaderPicture = new Picture(imageSourceLocations.Last());

                foreach (var imageSourceLocation in imageSourceLocations)
                {
                    Pictures.Insert(0, new Picture(imageSourceLocation));
                }
            }
            else
            {
                HeaderPicture = new Picture("journey3");
                Pictures.Add(new Picture("pictureDefault"));
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
                // Filename from Event ID and picture number
                // Pattern for Event 1, 2nd Picture: {1}2.jpg
                var idPatternForFileWithoutFileExtension = SelectedEvent.IdForFileSystem + Pictures.Count;
                _pictureSaver.SavePictureToDisk(picture.ImageSource, idPatternForFileWithoutFileExtension);
            }

            // add to view
            Pictures.Insert(0, picture);
        }
        private void ResetPictures()
        {
            Pictures.Remove(p => true);
            _pictureSaver.RemoveAllPictures(SelectedEvent.IdForFileSystem);
        }
        #endregion
    }
}
