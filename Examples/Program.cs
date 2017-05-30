using System;
using System.IO;
using System.Linq;
using W3CParser.Parser;
using W3CParser.Extensions;
using static W3CParser.Extensions.W3CReaderExtensions;

namespace Examples
{
    class Program
    {
        // 
        static void Example200(TextReader textReader)
        {
            var reader = new W3CReader(textReader);
            foreach (var webevent in reader.Read().Where(w => w.Status >= 200 && w.Status < 300).Take(100)
                     .OrderBy(w => w.Status)
                     .ThenBy(w => w.Date)
                     .ThenBy(w => w.UriStem)
                     .ThenBy(w => w.UriQuery))
            {
                Console.WriteLine("{0} {1}", webevent.Status.ToString().Red().Bold(), webevent.UriStem);
            }
        }

        // Return a listing of Web pages, and referring pages, that returned a 500 status code
        static void Example500(TextReader textReader)
        {
            var reader = new W3CReader(textReader);
            foreach (var webevent in reader.Read().Where(w => w.Status >= 500 && w.Status <= 600)
                     .OrderBy(w => w.Status)
                     .ThenBy(w => w.Date)
                     .ThenBy(w => w.UriStem)
                     .ThenBy(w => w.UriQuery))
            {
                Console.WriteLine("{0}\t{1}\t{2}{3}", webevent.Status.ToString().Red().Bold(),
                                  webevent.ToLocalTime(),
                                  webevent.UriStem.Blue(),
                                  webevent.UriQuery.Yellow());
            }
        }

        static void AverageResponseTimeByHalfHour(TextReader textReader)
        {
            var q = new W3CReader(textReader).Read()
                                             .Where(e => e.Status < 400)
                                             .GroupBy(r => r.UtcTime().RoundUp(TimeSpan.FromMinutes(30)))
                                             .Select(g => new
                                             {
                                                 HalfHour = g.Key,
                                                 AverageTimeTaken = g.Average((e) => e.TimeTaken)
                                             });
            foreach (var r in q)
            {
                Console.WriteLine("{0}\t{1}", r.HalfHour.ToLocalTime(), r.AverageTimeTaken);
            }
        }

        static void RequestsByHourPerDay(TextReader textReader)
        {
            var q = new W3CReader(textReader).Read()
                                             .GroupBy(r => r.UtcTime().RoundUp(TimeSpan.FromHours(1)))
                                 .Select(g => new
                                 {
                                     HalfHour = g.Key,
                                     Count = g.Count()
                                 });
            foreach (var r in q)
            {
                Console.WriteLine("{0}\t{1}", r.HalfHour, r.Count);
            }
        }

        static void CountOfDirectoryOfPathsRequested(TextReader textReader)
        {
            var q = new W3CReader(textReader).Read()
                                             .GroupBy(r => ExtractPath(r.UriStem))
                                             .Select(g => new
                                             {
                                                 Count = g.Count(),
                                                 Paths = g.Key
                                             }).OrderByDescending(g => g.Count);

            foreach (var r in q)
            {
                Console.WriteLine("{0}\t{1}", r.Count, r.Paths);
            }
        }

        static void CountOfExtensionsRequested(TextReader textReader)
        {
            var q = new W3CReader(textReader).Read()
                                             .GroupBy(r => ExtractExtension(r.UriStem))
                                             .Select(g => new
                                             {
                                                 Count = g.Count(),
                                                 Paths = g.Key
                                             }).OrderByDescending(g => g.Count);

            foreach (var r in q)
            {
                Console.WriteLine("{0}\t{1}", r.Count, r.Paths);
            }
        }

        static void Main(string[] args)
        {
            RequestsByHourPerDay(File.OpenText(args[0]));
        }
    }
}
