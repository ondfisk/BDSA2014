using System;
using Windows.UI.Xaml.Data;

namespace App1.Converters
{
    public class DateTimeToStringConverter: IValueConverter
    {
        public object Convert(object value, Type type, object parameter, string language)
        {
            string result;

            if (value is DateTime)
            {
                var theDate = (DateTime)value;
                result = string.Format("{0:d}", theDate);
            }
            else
            {
                var theDate = DateTime.Now;
                result = string.Format("{0:d}", theDate);
            }

            return result;
        }

        public object ConvertBack(object value, Type type, object parameter, string language)
        {
            return System.Convert.ToDateTime(value);
        }
    }
}
