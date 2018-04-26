using System;
using System.Globalization;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// a converter that takes in datetime and converts it to a user friendly message read time time
    /// </summary>
    public class TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //get the time passed in
            var time = (DateTimeOffset)value;

            //if it is not read...
            if (time == DateTimeOffset.MinValue)
                //show nothing
                return string.Empty;

            //if it is today...
            if (time.Date == DateTimeOffset.UtcNow.Date)
                //return just time
                return $"Read {time.ToLocalTime().ToString("HH:mm")}";

            //otherwise, return a full date
            return $"Read {time.ToLocalTime().ToString("HH:mm, MMM yyyy")}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}