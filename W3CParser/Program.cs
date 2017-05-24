using System;
using System.IO;
using System.Linq;
using System.Net;
using W3CParser.Extensions;
using W3CParser.Instrumentation;
using W3CParser.Parser;

namespace W3CParser
{
    class Program
    {
        static void Main(string[] args)
        {            
            var reader = new W3CReader(File.OpenText(args.Length > 0 ? args[0] : "Data/sample.log"));
         
            using (new ConsoleAutoStopWatch())
            {
                foreach (var @event in reader.Read().Where(e => e.Status == (int)HttpStatusCode.NotFound && e.UriStem.EndsWith(".exe", StringComparison.CurrentCultureIgnoreCase)))
                {
                    Console.WriteLine("{0} ({1}):{2}/{3}",
                                      @event.Status.ToString().Red().Bold(),
                                      @event.ToLocalTime(),
                                      @event.UriStem.Green(),
                                      @event.UriQuery);
                }
            }
        }
    }
}
