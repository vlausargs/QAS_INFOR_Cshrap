using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD.Triggers
{
    public interface IRecordCollectionWithDeletedInternal : IRecordCollectionWithDeleted
    {
        void SetColumnModified(string columnName);
    }
}
