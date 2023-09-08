using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD.Triggers
{
    public interface IRecordCollectionWithDeleted : IRecordCollection
    {
        bool IsUpdated(string columnName);
        new IRecordWithDeleted this[int recordPostion] { get; }
    }
}
