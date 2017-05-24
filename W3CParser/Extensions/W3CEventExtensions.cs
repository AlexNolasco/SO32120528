using System;
using W3CParser.Model;

namespace W3CParser.Extensions
{
    public static class W3CEventExtensions
    {
        public static int TimeTakenInSeconds(this W3CEvent w3cEvent) => w3cEvent.TimeTaken / 1000;

        public static DateTimeOffset ToLocalTime(this W3CEvent w3cEvent)
        {
            return UtcTime(w3cEvent).ToLocalTime();
        }

        public static DateTimeOffset UtcTime(this W3CEvent w3cEvent)
        {
			return new DateTimeOffset(w3cEvent.Date.Year,
												 w3cEvent.Date.Month,
												 w3cEvent.Date.Day,
												 w3cEvent.Time.Hour,
												 w3cEvent.Time.Minute,
												 w3cEvent.Time.Second,
												 w3cEvent.Date.Offset);
        }
    }
}
