using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using W3CParser.Convertors;

namespace W3CParser.Model
{
    sealed class W3CFieldMap
    {
        public sealed class W3CFieldMapInfo
        {
            readonly public ITextConvertor Convertor;
            readonly public FieldInfo FieldInfo;

            public W3CFieldMapInfo(ITextConvertor convertorType, FieldInfo fieldInfo)
            {
                Convertor = convertorType;
                FieldInfo = fieldInfo;
            }
        }

        readonly Dictionary<int, W3CFieldMapInfo> FieldDictionary = new Dictionary<int, W3CFieldMapInfo>(16);

        #region Public
        public bool IsEmpty() { return !FieldDictionary.Any(); }

        public bool ContainsKey(int key)
        {
            return FieldDictionary.ContainsKey(key);
        }

        public W3CFieldMapInfo this[int key]
        {
            get
            {
                return FieldDictionary[key];
            }
        }

        public void Add(int fieldIndex, ITextConvertor convertorType, FieldInfo fieldInfo)
        {
            FieldDictionary.Add(fieldIndex, new W3CFieldMapInfo(convertorType, fieldInfo));
        }
        #endregion
    }
}
