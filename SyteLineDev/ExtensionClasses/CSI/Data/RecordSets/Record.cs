using CSI.Data.CRUD.Triggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.RecordSets
{
    public class Record : IRecord, IRecordInternal, IRecordWithDeleted
    {
        readonly Dictionary<string, object> Data;
        readonly IRecordCollectionWithDeletedInternal parentCollection;
        IDataConverter dataConverter;
        readonly Dictionary<string, object> DeletedData = new Dictionary<string, object>();

        public Record(Dictionary<string, object> data, IRecordCollectionWithDeletedInternal parentCollection, IDataConverter dataConverter)
        {
            this.Data = data;
            this.parentCollection = parentCollection;
            this.dataConverter = dataConverter;
        }

        string IRecordInternal.MGItemID => null;

        public IEnumerable<string> ModifiedColumns => DeletedData.Keys;

        public object GetValue(string columnName) => Data[columnName];

        public void SetValue(string columnName, object value) { Data[columnName] = value; }

        public bool Contains(string columnName) { return Data.ContainsKey(columnName); }

        public T GetValue<T>(string columnName)
        {
            if (!Data.ContainsKey(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            var v = Data[columnName];

            return dataConverter.ToGeneric<T>(v);
        }

        public T GetValue<T>(int columnIndex)
        {
            if (columnIndex > Data.Count())
                throw new ArgumentOutOfRangeException($"Column Index is out of range from the record.");

            var v = Data.Values.ElementAt(columnIndex);

            return dataConverter.ToGeneric<T>(v);
        }

        public T GetValue<T>(string columnName, T valueWhenNull) where T : struct
        {
            if (!Data.ContainsKey(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            var v = Data[columnName];

            return dataConverter.ToGeneric<T>(v, valueWhenNull);
        }

        public void SetValue<T>(string columnName, object value)
        {
            if (!Data.ContainsKey(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            if (!DeletedData.ContainsKey(columnName))
            {
                //save off the original value
                parentCollection.SetColumnModified(columnName);
                DeletedData[columnName] = ((IRecordInternal)this).GetValue(columnName);
            }

            if (value is IUDDTType uDDTValue)
                value = uDDTValue.Value;
            else if (!(value is T))
                value = dataConverter.ChangeType<T>(value);

            Data[columnName] = value;
        }

        public void SetValue<T>(string columnName, T value)
        {
            if (!Data.ContainsKey(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            if (!DeletedData.ContainsKey(columnName))
            {
                //save off the original value
                parentCollection.SetColumnModified(columnName);
                DeletedData[columnName] = ((IRecordInternal)this).GetValue(columnName);
            }

            Data[columnName] = value is IUDDTType uDDTValue ? uDDTValue.Value : value;
        }

        public T GetDeletedValue<T>(string columnName)
        {
            if (!parentCollection.IsUpdated(columnName))
                //this was not an updated column
                return GetValue<T>(columnName);

            object value;
            if (DeletedData.TryGetValue(columnName, out value))
                //return the old value if there is one
                return dataConverter.ToGeneric<T>(value);

            //the column had updates, but not this particular record
            return GetValue<T>(columnName);
        }

        public T GetDeletedValue<T>(string columnName, T valueWhenNull) where T : struct
        {
            if (!parentCollection.IsUpdated(columnName))
                //this was not an updated column
                return GetValue<T>(columnName, valueWhenNull);

            object value;
            if (DeletedData.TryGetValue(columnName, out value))
            {
                //return the old value if there is one
                if (value == null || value is DBNull) return valueWhenNull;
                return dataConverter.ToGeneric<T>(value);
            }

            //the column had updates, but not this particular record
            return GetValue<T>(columnName, valueWhenNull);
        }
    }
}