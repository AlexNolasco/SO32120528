using System;
using W3CParser.Convertors;

namespace W3CParser.Attributes
{
	abstract class W3CFieldBaseAttribute : Attribute
	{
		public readonly string FieldName;
		public readonly ITextConvertor Convertor;

		protected W3CFieldBaseAttribute(string name)
		{
			FieldName = name;
		}

		protected W3CFieldBaseAttribute(string name, ITextConvertor convertor)
		{
			FieldName = name;
			Convertor = convertor;
		}
	}

	class W3CFieldAttribute : W3CFieldBaseAttribute
	{
		public W3CFieldAttribute(string name) : base(name, new StringConvertor())
		{
		}
	}

	class W3CFieldTimeAttribute : W3CFieldBaseAttribute
	{
		public W3CFieldTimeAttribute(string name) : base(name, new TimeConvertor())
		{
		}
	}

	class W3CFieldDateAttribute : W3CFieldBaseAttribute
	{
		public W3CFieldDateAttribute(string name) : base(name, new DateTimeOffsetConvertor())
		{
		}
	}

	class W3CInt32Attribute : W3CFieldBaseAttribute
	{
		public W3CInt32Attribute(string name) : base(name, new Int32Convertor())
        {
        }
	}
}
