using System;
using System.Globalization;

namespace Helpers
{
    public static class DateExtensions
    {
        public static bool IsValidDate(string value, string[] dateFormats)
        {
            DateTime dt;
            if (!DateTime.TryParseExact(value, dateFormats, 
                            System.Globalization.CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dt))
                return false;
            else
                return true;
        }
    }
}