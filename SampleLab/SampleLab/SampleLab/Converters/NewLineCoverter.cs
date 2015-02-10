

using System;
using Xamarin.Forms;
namespace SampleLab.Converters
{
    public class NewLineCoverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = String.Empty;
            if (value != null)
            {
                result = value.ToString();
                result = result.Replace("\n",Environment.NewLine);
            }
            return result;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
