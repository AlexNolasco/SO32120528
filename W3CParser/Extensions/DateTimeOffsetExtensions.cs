using System;
namespace W3CParser.Extensions
{
    public static class DateTimeOffsetExtensions
    {

        public static DateTimeOffset RoundUp(this DateTimeOffset dateTime, TimeSpan timeSpan)
        {         
            return new DateTimeOffset(((dateTime.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks) * timeSpan.Ticks, TimeSpan.Zero);
        }
    }
}
