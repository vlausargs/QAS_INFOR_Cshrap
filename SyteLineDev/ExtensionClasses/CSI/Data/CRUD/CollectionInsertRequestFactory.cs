using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionInsertRequestFactory : ICollectionInsertRequestFactory
    {
        public ICollectionInsertRequest IDOInsert(string idoName, IRecordCollection items)
        {
            return CollectionInsertRequest.IDOInsert(idoName, items);
        }

        public ICollectionInsertRequest SQLInsert(string tableName, IRecordCollection items)
        {
            return CollectionInsertRequest.SQLInsert(tableName, items);
        }

        public ICollectionInsertRequest SQLInsert(string tableName, IReadOnlyDictionary<string, object> valuesByColumnToAssign)
        {
            return CollectionInsertRequest.SQLInsert(tableName, valuesByColumnToAssign);
        }
    }
}
