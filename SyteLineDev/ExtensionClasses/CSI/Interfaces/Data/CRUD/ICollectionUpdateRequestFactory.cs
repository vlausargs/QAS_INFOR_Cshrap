using CSI.Data.CRUD.Triggers;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionUpdateRequestFactory
    {
        /* commented out until statement-level extensibility is designed
        /// <summary>
        /// Create an update request object that describes a set of record changes to be made via a mongoose IDO.
        /// </summary>
        /// <param name="idoName">The name of the IDO through which to change the records.</param>
        /// <param name="items">The set of modified records.</param>
        /// <returns></returns>
        ICollectionUpdateRequest IDOUpdate(string idoName, IRecordCollectionWithDeleted items);
        */

        /// <summary>
        /// Create an update request object that describes a set of record changes to be made via direct SQL DML.
        /// </summary>
        /// <param name="tableName">The name of the table containing the records to be changed.</param>
        /// <param name="items">The set of modified records.</param>
        /// <returns></returns>
        ICollectionUpdateRequest SQLUpdate(string tableName, IRecordCollectionWithDeleted items);

        /// <summary>
        /// Create an update request object that describes a record change to be made via direct SQL DML.
        /// </summary>
        /// <param name="tableName">The name of the table containing the record to be changed.</param>
        /// <param name="valuesByColumnToAssign">The new column values by column name.</param>
        /// <param name="whereClauseValuesByKeyColumn">The primary key of the record to update.</param>
        /// <returns></returns>
        ICollectionUpdateRequest SQLUpdate(
            string tableName,
            IReadOnlyDictionary<string, object> valuesByColumnToAssign,
            IReadOnlyDictionary<string, object> whereClauseValuesByKeyColumn);
    }
}
