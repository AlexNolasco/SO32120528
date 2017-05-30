using System;
namespace W3CParser.Extensions
{
    public static class IntExtensions
    {
        public static DateTimeOffset Quantize(this int timeInMilliseconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timeInMilliseconds / 1000);
        }
    }
}
