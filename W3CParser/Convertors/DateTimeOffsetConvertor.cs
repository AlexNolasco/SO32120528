using System;
using System.Globalization;

namespace W3CParser.Convertors
{
    public class DateTimeOffsetConvertor : ITextConvertor
    {
        public dynamic Convert(string text) => DateTimeOffset.ParseExact(text, "yyyy'-'MM'-'dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
    }
}
