using System;
using System.IO;
using System.Linq;
using W3CParser.Instrumentation;
using W3CParser.Parser;

namespace W3CParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            var reader = new W3CReader(File.OpenText(args.Length > 0 ? args[0] : "Data/sample.log"));
            var hits = 0;
			using (new ConsoleAutoStopWatch())
			{
                //foreach (var request in reader.Read().GroupBy(e => e.ClientIpAddress)
                //    .Select(group => new
                //    {
                //        Metric = group.Key,
                //        Count = group.Count()
                //    })
                //.OrderByDescending(x => x.Count))
                //{
                //    Console.WriteLine("{0} {1}", request.Metric, request.Count);
                //}

                //foreach (var request in reader.Read().Where(e => e.TimeTaken > 12000))
                //{
                //	Console.WriteLine("{0} {1} {2} {3} {4}\t{5}", request.Status, request.TimeTaken / 1000, request.ClientIpAddress,
                //		request.UriStem, request.BytesSent, request.UriQuery);
                //}


				foreach (var request in reader.Read())
				{
                    hits += 1;
				    //Console.WriteLine(request.ClientIpAddress);
				}
			}
            Console.WriteLine("Done.. {0} {1}", hits, reader.Software );
			Console.ReadKey();
        }
    }
}
