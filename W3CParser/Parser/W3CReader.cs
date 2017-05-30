using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using W3CParser.Model;

namespace W3CParser.Parser
{
    public sealed class W3CReader
	{
        public String Software { get; private set; }
	    TextReader Reader { get; }
		
		public W3CReader(TextReader reader)
		{
			Reader = reader;
		}

		string RightOf(string token, string line)
		{
			var returnValue = line.Substring(token.Length + 2);
			return returnValue;
		}

		void ParseHeader(string line, Action<string> fieldsBlock)
		{			
            const string commentFields = "#Fields";
            const string commentSoftware = "#Software";

            if (line.StartsWith(commentSoftware, StringComparison.OrdinalIgnoreCase))
            {
                Software = RightOf(commentSoftware, line);
            }
            else if (line.StartsWith(commentFields, StringComparison.OrdinalIgnoreCase))
			{
				fieldsBlock(RightOf(commentFields, line));
			}
		}

		public IEnumerable<W3CEvent> Read()
		{			
			var itemParser = new W3CItemsParser();
			var fieldMap = (W3CFieldMap)null;
            var line = (string)null;

			while ((line = Reader.ReadLine()) != null)
			{
                if (line.StartsWith("#", StringComparison.OrdinalIgnoreCase))
				{
					ParseHeader(line, (fieldsLine) =>
					{
						fieldMap = new W3CFieldsParser().Parse(fieldsLine);
					});
					continue;
				}

				if (fieldMap == null)
					continue;

				yield return itemParser.Parse(line, fieldMap);
			}
		}
	}
}
