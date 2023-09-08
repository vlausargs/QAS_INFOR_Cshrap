using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CSI.Data.RecordSets
{
    public interface IRecordReadOnly
    {
        bool Contains(string columnName);
        T GetValue<T>(string columnName);
        T GetValue<T>(int columnIndex);
        T GetValue<T>(string columnName, T valueWhenNull) where T : struct;

        /// <summary>
        /// Reserved for internal use
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        object GetValue(string columnName);
    }
}