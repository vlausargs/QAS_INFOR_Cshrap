using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadRequest
    {
        //Mongoose ==============================================================

        /// <summary>
        /// The name of the IDO to use, if available.
        /// </summary>
        string IDOName { get; }

        /// <summary>
        /// The where clause to use with the IDO, if available.
        /// </summary>
        string IDOWhereClause { get; }

        /// <summary>
        /// The order-by clause to use with the IDO, if available.
        /// </summary>
        string IDOOrderByClause { get; }

        //SQL ====================================================================

        /// <summary>
        /// The name of the SQL table to use, if available.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// The name of the SQL table to be updated or deleted, if available
        /// </summary>
        string TargetTableName { get; }

        /// <summary>
        /// The from clause to use in the SQL DML, if available.  Any needed joins are included here as well.
        /// </summary>
        IParameterizedCommand FromClause { get; }

        /// <summary>
        /// The parameterized where clause to use in the SQL DML, if available.
        /// </summary>
        IParameterizedCommand WhereClause { get; }

        /// <summary>
        /// The order-by clause to use in the SQL DML, if available.
        /// </summary>
        IParameterizedCommand OrderByClause { get; }

        /// <summary>
        /// The columns of the result set.
        /// </summary>
        IEnumerable<string> RequestedColumns { get; }

        /// <summary>
        /// The SQL DML expression associated with each column.
        /// </summary>
        IReadOnlyDictionary<string, string> ColumnExpressionByColumnName { get; }

        /// <summary>
        /// The column name associated with each IUDDTType variable.
        /// </summary>
        IReadOnlyDictionary<IUDDTType, string> ColumnNameByVariableToAssign { get; }

        /// <summary>
        /// The column name associated with each column and have parameterized value.
        /// </summary>
        IReadOnlyDictionary<string, IParameterizedCommand> ColumnParametizedByColumnName { get; }

        /// <summary>
        /// The column name associated with each IUDDTType variables and have parameterized value.
        /// </summary>
        IReadOnlyDictionary<IUDDTType, IParameterizedCommand> ColumnParametizedByVariableToAssign { get; }

        /// <summary>
        /// The maximum number of records to load, or zero if there is no limit.
        /// </summary>
        int MaximumRows { get; }

        /// <summary>
        /// When true, the records in the result set will not be modifiable.
        /// </summary>
        bool LoadForChange { get; }

        //=========================================================================

        /// <summary>
        /// True when this object supplies sufficient information to perform the load via an IDO
        /// </summary>
        bool CanIDO { get; }

        /// <summary>
        /// True when this object supplies sufficient information to perform the load via SQL DML
        /// </summary>
        bool CanSQL { get; }

        /* commented out until statement-level extensibility is designed
        /// <summary>
        /// Augment this existing request with the information needed to service the request via an IDO.
        /// </summary>
        /// <param name="idoName">The name of the IDO to use.</param>
        /// <param name="idoWhereClause">Optional.  The where clause to use with the IDO.</param>
        /// <param name="idoOrderByClause">Optional.  The order-by clause to use with the IDO</param>
        /// <returns></returns>
        ICollectionLoadRequest AddIDOIntercept(
           string idoName,
           string idoWhereClause = null,
           string idoOrderByClause = null);
        */
        LockingType LockingType { get; }
    }
}
