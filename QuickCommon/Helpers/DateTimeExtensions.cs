using System;
//
namespace BadBetaSoftware.Quick.Common.Helpers
{
    public static class DateTimeExtensions
    {
        // https://stackoverflow.com/a/38064/3938401
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
