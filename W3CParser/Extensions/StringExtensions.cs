using System;
namespace W3CParser.Extensions
{
    public static class StringExtensions
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
			if (!String.IsNullOrWhiteSpace(text))
			{
				var charLocation = text.LastIndexOf(stopAt, StringComparison.Ordinal);

				if (charLocation > 0)
				{
					return text.Substring(0, charLocation + 1);
				}
			}

			return String.Empty;            
        }

        public static string GetLastOfOrEmpty(this string text, string stopAt = "-")
		{
			if (!String.IsNullOrWhiteSpace(text))
			{
                var charLocation = text.LastIndexOf(stopAt, StringComparison.Ordinal);

				if (charLocation > 0)
				{
                    return text.Substring(charLocation + 1);
				}
			}

			return String.Empty;
		}
    }
}
