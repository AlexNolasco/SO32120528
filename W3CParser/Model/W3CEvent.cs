using System;
using W3CParser.Attributes;

namespace W3CParser.Model
{
    public sealed class W3CEvent
    {
        [W3CFieldDate("date")]
		public DateTimeOffset Date;
		[W3CFieldTime("time")]
		public DateTimeOffset Time;
		[W3CField("s-ip")]
		public string ServerIpAddress;
		[W3CField("cs-method")]
		public string Method;
		[W3CField("cs-uri-stem")]
		public string UriStem;
		[W3CField("cs-uri-query")]
		public string UriQuery;
		[W3CInt32("s-port")]
		public int Port;
		[W3CField("cs-username")]
		public string Username;
		[W3CField("c-ip")]
		public string ClientIpAddress;
		[W3CField("cs(User-Agent)")]
		public string Agent;
		[W3CField("cs(Referer)")]
		public string Referer;
		[W3CInt32("sc-status")]
		public int Status;
		[W3CInt32("sc-substatus")]
		public int SubStatus;
		[W3CInt32("sc-win32-status")]
		public int Win32Status;
		[W3CInt32("time-taken")]
		public int TimeTaken;
		[W3CInt32("sc-bytes")]
		public int BytesSent;
		[W3CInt32("cs-bytes")]
		public int BytesReceived;
		[W3CField("host")]
		public string Host;
    }
}
