using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BoilerPlate.ViewModel
{
    public class RadiusViewModel: ViewModelBase
    {
        private readonly int DEFINED_BOX_LENGTH = 150;
        private double _borderRadius;
        private double _sliderValue;

        public RadiusViewModel()
        {
            //SliderChangedCommand = new RelayCommand(SetRadius);
        }

        public RelayCommand SliderChangedCommand { get; set; }
        public int BoxLength => DEFINED_BOX_LENGTH;

        public double SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                BorderRadius = value;
                RaisePropertyChanged(nameof(SliderValue));
            }
        }

        public double BorderRadius
        {
            get { return _borderRadius; }
            // Property needs to be set directly from slider.
            // Value between 0 and 1 calculates the according radius.
            set
            {
                _borderRadius = (DEFINED_BOX_LENGTH/2) * value;
                RaisePropertyChanged(nameof(BorderRadius));
            }
        }

        public void Init()
        {
            SliderValue = 0.5;
        }
        //private void SetRadius()
        //{
        //    SliderValue
        //}
    }
}
