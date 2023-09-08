using CSI.Data.CRUD.Triggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionUpdateRequest
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
        /// The collection of records with changes, if specified.
        /// </summary>
        IRecordCollectionWithDeleted Items { get; }

        /// <summary>
        /// The changes by column, if specified.
        /// </summary>
        IReadOnlyDictionary<string, object> ValuesByColumnToAssign { get; }

        /// <summary>
        /// The primary key of the record to update, if specified.
        /// </summary>
        IReadOnlyDictionary<string, object> ValuesByKeyColumn { get; }

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
        ICollectionUpdateRequest AddIDOIntercept(string idoName, IRecordCollectionWithDeleted items);
        */
    }
}
