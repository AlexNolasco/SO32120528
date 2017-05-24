using System;
using System.Linq;
using System.Reflection;
using W3CParser.Attributes;
using W3CParser.Model;

namespace W3CParser.Parser
{
	class W3CFieldsParser
	{
		void GetFieldAttributeByName(string name, FieldInfo[] w3cFields, Action<W3CFieldBaseAttribute, FieldInfo> foundBlock)
		{
			for (var fieldIndexPosition = 0; fieldIndexPosition < w3cFields.Length; fieldIndexPosition++)
			{
                var w3cField = w3cFields[fieldIndexPosition];
                var fieldAttribute = (W3CFieldBaseAttribute)w3cField.GetCustomAttributes(typeof(W3CFieldBaseAttribute), false).FirstOrDefault();
                if (fieldAttribute != null && fieldAttribute.FieldName == name)
                {
                    foundBlock(fieldAttribute, w3cField);
                    break;
                }
			}
		}

		public W3CFieldMap Parse(string line)
		{
			var fieldMap = new W3CFieldMap();
			var w3cFields = typeof(W3CEvent).GetFields();
			var lineFields = line.Split(' ');
            var lineFieldsIndex = 0;

            foreach(var lineField in lineFields)
            {
				GetFieldAttributeByName(lineField, w3cFields, (fieldAttribute, fieldInfo) =>
				{
					fieldMap.Add(lineFieldsIndex, fieldAttribute.Convertor, fieldInfo);
				});
                lineFieldsIndex += 1;
			}
			return fieldMap;
		}
	}
}
