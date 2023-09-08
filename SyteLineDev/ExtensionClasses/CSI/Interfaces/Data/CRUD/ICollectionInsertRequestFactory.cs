using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionInsertRequestFactory
    {
        /* commented out until statement-level extensibility is designed
        /// <summary>
        /// Create an insert request object that describes a set of record additions to be made via a mongoose IDO.
        /// </summary>
        /// <param name="idoName">The name of the IDO through which to add the records.</param>
        /// <param name="items">The set of records to insert.</param>
        /// <returns></returns>
        ICollectionInsertRequest IDOInsert(string idoName, IRecordCollection items);
        */

        /// <summary>
        /// Create an insert request object that describes a set of record additions to be made via direct SQL DML.
        /// </summary>
        /// <param name="tableName">The name of the table to insert the records into.</param>
        /// <param name="items">The set of records to insert.</param>
        /// <returns></returns>
        ICollectionInsertRequest SQLInsert(string tableName, IRecordCollection items);

        /// <summary>
        /// Create an insert request object that will insert one record via direct SQL DML.
        /// </summary>
        /// <param name="tableName">The name of the table to insert the record into.</param>
        /// <param name="valuesByColumnToAssign">The column values by column name.</param>
        /// <returns></returns>
        ICollectionInsertRequest SQLInsert(string tableName, IReadOnlyDictionary<string, object> valuesByColumnToAssign);
    }
}
