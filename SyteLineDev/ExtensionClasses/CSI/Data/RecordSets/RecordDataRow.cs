using CSI.Data.CRUD.Triggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.RecordSets
{
    public class RecordDataRow : IRecord, IRecordInternal, IRecordWithDeleted
    {
        DataRow dataRow { get; }
        IRecordCollectionWithDeletedInternal parentCollection { get; }

        Dictionary<string, object> DeletedData = new Dictionary<string, object>();

        public RecordDataRow(DataRow row, IRecordCollectionWithDeletedInternal parentCollection)
        {
            this.dataRow = row;
            this.parentCollection = parentCollection;
        }

        string IRecordInternal.MGItemID => null;

        public IEnumerable<string> ModifiedColumns => DeletedData.Keys;

        public object GetValue(string columnName) => dataRow[columnName];

        public void SetValue(string columnName, object value) { dataRow[columnName] = value; }

        public bool Contains(string columnName) { return dataRow.Table.Columns.Contains(columnName); }

        public T GetValue<T>(string columnName)
        {
            if (!dataRow.Table.Columns.Contains(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            var v = dataRow[columnName];
            if (v == null || v is DBNull)
            {
                if (typeof(T).GetInterfaces().Contains(typeof(IUDDTType)))
                    return CreateUDDTDefault<T>();
                return default(T);
            }
            if (v is T) return (T)v;
            return (T)ChangeType(v, typeof(T));
        }

        public T GetValue<T>(int columnIndex)
        {
            if (columnIndex > dataRow.Table.Columns.Count - 1)
                throw new ArgumentOutOfRangeException($"Column Index is out of range from the record.");

            var v = dataRow[columnIndex];
            if (v == null || v is DBNull)
            {
                if (typeof(T).GetInterfaces().Contains(typeof(IUDDTType)))
                    return CreateUDDTDefault<T>();
                return default(T);
            }
            if (v is T) return (T)v;
            return (T)ChangeType(v, typeof(T));
        }

        public T GetValue<T>(string columnName, T valueWhenNull) where T : struct
        {
            if (!dataRow.Table.Columns.Contains(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            var v = dataRow[columnName];
            if (v == null || v is DBNull) return valueWhenNull;
            if (v is T) return (T)v;
            return (T)ChangeType(v, typeof(T));
        }
        public void SetValue<T>(string columnName, object value)
        {
            if (!dataRow.Table.Columns.Contains(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            if (!DeletedData.ContainsKey(columnName))
            {
                //save off the original value
                parentCollection.SetColumnModified(columnName);
                DeletedData[columnName] = ((IRecordInternal)this).GetValue(columnName);
            }
            if (value is IUDDTType uDDTValue)
            {
                dataRow[columnName] = uDDTValue.Value;
                return;
            }
            if (value is T)
            {
                dataRow[columnName] = value;
                return;
            }

            dataRow[columnName] = (T)ChangeType(value, typeof(T));
        }
        public void SetValue<T>(string columnName, T value)
        {
            if (!dataRow.Table.Columns.Contains(columnName))
                throw new ArgumentException($"Column name {columnName} does not exist in the record.");

            if (!DeletedData.ContainsKey(columnName))
            {
                //save off the original value
                parentCollection.SetColumnModified(columnName);
                DeletedData[columnName] = ((IRecordInternal)this).GetValue(columnName);
            }
            if (value is IUDDTType uDDTValue)
            {
                dataRow[columnName] = uDDTValue.Value;
                return;
            }
            dataRow[columnName] = value;
        }

        public T GetDeletedValue<T>(string columnName)
        {
            if (!parentCollection.IsUpdated(columnName))
                //this was not an updated column
                return GetValue<T>(columnName);

            object value;
            if (DeletedData.TryGetValue(columnName, out value))
                //return the old value if there is one
                return (T)value;

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
                return (T)value;
            }

            //the column had updates, but not this particular record
            return GetValue<T>(columnName, valueWhenNull);
        }

        private object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }


            var fullName = value?.GetType().FullName;
            if (fullName != null && (t.FullName.Contains("CSI.Data.SQL.UDDT")
                                     && fullName.Contains("CSI.Data.SQL.UDDT") == false))
            {
                foreach (var constructorInfo in conversion.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
                {
                    try
                    {
                        return constructorInfo.Invoke(new object[] { value });
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
            if (value is IUDDTType newValue)
                value = newValue.Value;

            return Convert.ChangeType(value, t);
        }

        private T CreateUDDTDefault<T>()
        {
            foreach (var constructorInfo in typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
            {
                try
                {
                    return (T)constructorInfo.Invoke(new object[] { null });
                }
                catch
                {
                    // ignored
                }
            }

            return default(T);
        }
    }
}