using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionInsertRequest
    {
        /// <summary>
        /// The name of the IDO to use, if available.
        /// </summary>
        string IDOName { get; }

        /// <summary>
        /// The name of the SQL table to use, if available.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// The collection of records to insert, if specified.
        /// </summary>
        IRecordCollection Items { get; }

        /// <summary>
        /// The new record values by column, if specified.
        /// </summary>
        IReadOnlyDictionary<string, object> ValuesByColumnToAssign { get; }

        /// <summary>
        /// True when this object supplies sufficient information to perform the update via an IDO
        /// </summary>
        bool CanIDO { get; }

        /// <summary>
        /// True when this object supplies sufficient information to perform the update via SQL DML
        /// </summary>
        bool CanSQL { get; }

        /* commented out until statement-level extensibility is designed
        /// <summary>
        /// Augment this existing request with the information needed to service the request via an IDO.
        /// </summary>
        /// <param name="idoName">The name of the IDO to use.</param>
        /// <param name="items">The collection of records with changes.</param>
        /// <returns></returns>
        ICollectionInsertRequest AddIDOIntercept(string idoName, IRecordCollection items);
        */
    }
}
