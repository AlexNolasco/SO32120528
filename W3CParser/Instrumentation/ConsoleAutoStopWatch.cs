using System;
using System.Diagnostics;

namespace W3CParser.Instrumentation
{
	public sealed class ConsoleAutoStopWatch : IDisposable
	{
	    readonly Stopwatch _stopWatch;

		public ConsoleAutoStopWatch()
		{
			_stopWatch = new Stopwatch();
			_stopWatch.Start();
		}

		public void Dispose()
		{
			_stopWatch.Stop();
			var ts = _stopWatch.Elapsed;

			var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
											   ts.Hours, ts.Minutes, ts.Seconds,
											   ts.Milliseconds / 10);
			Console.WriteLine(elapsedTime, "RunTime");
            Console.WriteLine("GC {0}", GC.CollectionCount(0));
		}
	}
}
