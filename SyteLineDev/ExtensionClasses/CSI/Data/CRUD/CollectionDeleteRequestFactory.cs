using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionDeleteRequestFactory : ICollectionDeleteRequestFactory
    {
        public ICollectionDeleteRequest IDODelete(string idoName, IRecordCollection items)
        {
            return CollectionDeleteRequest.IDODelete(idoName, items);
        }

        public ICollectionDeleteRequest SQLDelete(string tableName, IRecordCollection items)
        {
            return CollectionDeleteRequest.SQLDelete(tableName, items);
        }

        public ICollectionDeleteRequest SQLDelete(string tableName, IReadOnlyDictionary<string, object> valuesByKeyColumn)
        {
            return CollectionDeleteRequest.SQLDelete(tableName, valuesByKeyColumn);
        }
    }
}
