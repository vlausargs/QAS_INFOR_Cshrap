using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSI.Data.RecordSets
{
    [Serializable]
    public class RecordSole : IRecordReadOnly
    {
        Dictionary<string, object> data;
        IDataConverter dataConverter;
        public RecordSole(Dictionary<string, object> data, IDataConverter dataConverter)
        {
            this.data = data;
            this.dataConverter = dataConverter;
        }

        public bool Contains(string columnName) => data.ContainsKey(columnName);

        public T GetValue<T>(string columnName)
        {
            if (!data.ContainsKey(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            var v = data[columnName];

            return dataConverter.ToGeneric<T>(v);
        }

        public T GetValue<T>(int columnIndex)
        {
            if (columnIndex > data.Count())
                throw new ArgumentOutOfRangeException($"Column Index is out of range from the record.");

            var v = data.Values.ElementAt(columnIndex);

            return dataConverter.ToGeneric<T>(v);
        }

        public T GetValue<T>(string columnName, T valueWhenNull) where T : struct
        {
            if (!data.ContainsKey(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            var v = data[columnName];

            return dataConverter.ToGeneric<T>(v, valueWhenNull);
        }

        public object GetValue(string columnName) => data[columnName];
    }
}