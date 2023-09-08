using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionUpdateRequestFactory : ICollectionUpdateRequestFactory
    {
        public ICollectionUpdateRequest IDOUpdate(string idoName, IRecordCollectionWithDeleted items)
        {
            return CollectionUpdateRequest.IDOUpdate(idoName, items);
        }

        public ICollectionUpdateRequest SQLUpdate(string tableName, IRecordCollectionWithDeleted items)
        {
            return CollectionUpdateRequest.SQLUpdate(tableName, items);
        }

        public ICollectionUpdateRequest SQLUpdate(
            string tableName,
            IReadOnlyDictionary<string, object> valuesByColumnToAssign,
            IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            return CollectionUpdateRequest.SQLUpdate(tableName, valuesByColumnToAssign, valuesByKeyColumn);
        }
    }
}
