using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BoilerPlate.ViewModel
{
    public class ClickViewModel : ViewModelBase
    {
        private int _clickCount;

        public ClickViewModel()
        {
            IncrementCommand = new RelayCommand(Inctement);
        }

        public int ClickCount
        {
            get { return _clickCount; }
            set { _clickCount = value; RaisePropertyChanged(nameof(ClickCount)); }
        }
        public RelayCommand IncrementCommand { get; set; }
        private void Inctement()
        {
            ClickCount++;
        }

        public void Init()
        {
            ClickCount = 0;
        }
    }
}