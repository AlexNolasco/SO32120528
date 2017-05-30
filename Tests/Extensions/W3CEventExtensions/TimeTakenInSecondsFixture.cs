using System;
using W3CParser.Extensions;
using W3CParser.Model;
using Xunit;

namespace Tests.Extensions.W3CEventExtensions
{
    public class TimeTakenInSecondsFixture
    {
        [Fact]
        public void PassingTest()
        {
            var webevent = new W3CEvent();
            webevent.TimeTaken = 1000;
            Assert.Equal(1, webevent.TimeTakenInSeconds());
        }

		[Fact]
		public void ZeroTest()
		{
			var webevent = new W3CEvent();
			webevent.TimeTaken = 0;
			Assert.Equal(0, webevent.TimeTakenInSeconds());
		}
    }
}
