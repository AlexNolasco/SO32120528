using static W3CParser.Extensions.W3CReaderExtensions;
using Xunit;

namespace Tests.Extensions.W3CReaderExtensions
{
    public class ExtractPathFixture
    {
        [Fact]
        public void PassingTest()
        {
            var path = "/foo/";
            Assert.Equal("/foo/", ExtractPath(path));
        }

		[Fact]
		public void Filename()
		{
			var path = "/foo/default.aspx";
			Assert.Equal("/foo/", ExtractPath(path));
		}

		[Fact]
		public void Root()
		{
			var path = "/";
			Assert.Equal("/", ExtractPath(path));
		}

		[Fact]
		public void Empty()
		{
			var path = "";
			Assert.Equal("", ExtractPath(path));
		}

		[Fact]
		public void Null()
		{
            var path = (string)null;
			Assert.Equal(null, ExtractPath(path));
		}
    }
}
