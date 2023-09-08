using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CSI.Data.RecordSets
{
    public interface IRecord : IRecordReadOnly
    {
        void SetValue<T>(string columnName, T value);
        void SetValue<T>(string columnName, object value);
        T GetDeletedValue<T>(string columnName);
        /// <summary>
        /// Reserved for internal use
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void SetValue(string columnName, object value);
    }
}