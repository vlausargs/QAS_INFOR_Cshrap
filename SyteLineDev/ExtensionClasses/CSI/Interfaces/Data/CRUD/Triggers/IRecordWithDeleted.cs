using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD.Triggers
{
    public interface IRecordWithDeleted : IRecord
    {
        //T GetDeletedValue<T>(string columnName);  //Comment it since this method already exists in IRecord
        T GetDeletedValue<T>(string columnName, T valueWhenNull) where T : struct;
        IEnumerable<string> ModifiedColumns { get; }
    }
}
