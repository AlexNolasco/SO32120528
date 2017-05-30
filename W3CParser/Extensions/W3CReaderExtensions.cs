using System;
namespace W3CParser.Extensions
{
    public static class W3CReaderExtensions
    {
        public static string ExtractPath(string path)
        {
            if (String.IsNullOrEmpty(path))
                return path;            
			if (path == "/")
				return path;
            return path.GetUntilOrEmpty("/");
        }

        public static string ExtractFilename(string path)
        {
            return path.GetLastOfOrEmpty("/");
		}

        public static string ExtractExtension(string path)
        {         
            return ExtractFilename(path).GetLastOfOrEmpty(".");
        }
    }
}
