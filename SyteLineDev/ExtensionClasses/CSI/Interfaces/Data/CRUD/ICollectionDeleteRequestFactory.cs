using CSI.Data.RecordSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionDeleteRequestFactory
    {
        /*
        /// <summary>
        /// Create a delete request object that describes a set of record deletions to be made via a mongoose IDO.
        /// </summary>
        /// <param name="idoName">The name of the IDO through which to delete the records.</param>
        /// <param name="items">The set of records to delete.</param>
        /// <returns></returns>
        ICollectionDeleteRequest IDODelete(string idoName, IRecordCollection items);
        */

        /// <summary>
        /// Create an delete request object that describes a set of record deletions to be made via direct SQL DML.
        /// </summary>
        /// <param name="tableName">The name of the table to delete the records from.</param>
        /// <param name="items">The set of records to delete.</param>
        /// <returns></returns>
        ICollectionDeleteRequest SQLDelete(string tableName, IRecordCollection items);

        /// <summary>
        /// Create a delete request object that will delete one record via direct SQL DML.
        /// </summary>
        /// <param name="tableName">The name of the table to delete the record from.</param>
        /// <param name="whereClauseValuesByKeyColumn">The primary key of the record to delete.</param>
        /// <returns></returns>
        ICollectionDeleteRequest SQLDelete(string tableName, IReadOnlyDictionary<string, object> whereClauseValuesByKeyColumn);
    }
}
