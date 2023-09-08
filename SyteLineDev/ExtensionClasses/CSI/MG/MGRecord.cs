using CSI.Data.CRUD.Triggers;
using CSI.Data.RecordSets;
using Mongoose.Core.Common;
using Mongoose.IDO;
using Mongoose.IDO.DataAccess;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGRecord : IRecord, IRecordInternal, IRecordWithDeleted
    {
        LoadCollectionResponseData data;
        int recordPosition;
        IRecordCollectionWithDeletedInternal parentCollection;

        Dictionary<string, object> DeletedData = new Dictionary<string, object>();

        public MGRecord(LoadCollectionResponseData data, int recordPosition, IRecordCollectionWithDeletedInternal parentCollection)
        {
            this.data = data;
            this.recordPosition = recordPosition;
            this.parentCollection = parentCollection;
        }

        public bool Contains(string columnName) { return data.PropertyList.List.Contains(columnName); }

        string IRecordInternal.MGItemID => data.Items[recordPosition].ItemID;

        public IEnumerable<string> ModifiedColumns => DeletedData.Keys;

        object GetValueInternal(string columnName)
        {
            return data.Items[recordPosition].MGGetPropertyValue(columnName);
        }

        public void SetValue(string columnName, object value)
        {
            data[recordPosition, columnName].SetValue(value);
        }

        public T GetValue<T>(string columnName)
        {
            return data[recordPosition, columnName].GetValue<T>();
        }

        public T GetValue<T>(string columnName, T valueWhenNull) where T : struct
        {
            return data[recordPosition, columnName].GetValue(valueWhenNull);
        }

        public T GetValue<T>(int columnIndex)
        {
            return data[recordPosition, columnIndex].GetValue<T>();
        }

        public object GetValue(string columnName) => data[recordPosition, columnName].GetValue<object>();

        public void SetValue<T>(string columnName, object value)
        {
            if (!DeletedData.ContainsKey(columnName))
            {
                //save off the original value
                parentCollection.SetColumnModified(columnName);
                DeletedData[columnName] = ((IRecordInternal)this).GetValue(columnName);
            }

            if (value is T)
            {
                data[recordPosition, columnName].SetValue(value);
                return;
            }

            data[recordPosition, columnName].SetValue((T)ChangeType(value, typeof(T)));
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

            return Convert.ChangeType(value, t);
        }

        public void SetValue<T>(string columnName, T value)
        {
            if (!DeletedData.ContainsKey(columnName))
            {
                //save off the original value
                parentCollection.SetColumnModified(columnName);
                DeletedData[columnName] = ((IRecordInternal)this).GetValue(columnName);
            }

            data[recordPosition, columnName].SetValue(value);
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
    }
}