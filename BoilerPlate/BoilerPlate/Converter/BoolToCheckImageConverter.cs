using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoilerPlate.Converter
{
    public class BoolToCheckImageConverter : IValueConverter
    {
        public string TrueImageFileName { get; set; }
        public string FalseImageFileName { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
            {
                return FalseImageFileName;
            }
            return (bool)value ? TrueImageFileName : FalseImageFileName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
