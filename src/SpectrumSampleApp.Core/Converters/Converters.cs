using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace SpectrumSampleApp.Core.Converters
{
    public static class Converters
    {
        public static TruncatedTextConverter TruncatedTextConverter => new TruncatedTextConverter();
        public static ShortDateConverter ShortDateConverter => new ShortDateConverter();
        public static NegatedConverter NegatedConverter => new NegatedConverter();

    }

    public class TruncatedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.ToString().Length < 76)
                return value;

            return $"{value.ToString().Substring(0, 75)}...";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }


    public class ShortDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;

            DateTime date = System.Convert.ToDateTime(value);

            return date.ToString("yyyy-mm-dd-hh-mm");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
    public class NegatedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
