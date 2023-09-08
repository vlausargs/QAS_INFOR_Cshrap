using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadRequestFactory
    {
        /// <summary>
        /// Create an load request object that describes how to load data via direct SQL DML.  
        /// This API cannot be used with an IDO.
        /// </summary>
        /// <param name="columns">The table columns to load.</param>
        /// <param name="tableName">The name of the table to load data from.</param>
        /// <param name="loadForChange"> When false, returns a result set that cannot be altered.</param>
        /// <param name="lockingType"> This flag will add lock to primary table</param>
        /// <param name="fromClause">Optional.  The parameterized from clause, including any joins, to use.</param>
        /// <param name="whereClause">Optional.  The parameterized where clause to use.</param>
        /// <param name="orderByClause">Optional.  The order-by clause to use.</param>
        /// <param name="maximumRows">Optional.  The maximum number of records to load.  Use zero for no limit.</param>
        /// <returns></returns>
        ICollectionLoadRequest SQLLoad(
            IEnumerable<string> columns,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null,
            IParameterizedCommand orderByClause = null,
            int? maximumRows = 0,
            string targetTableName = null);

        /// <summary>
        /// Create an load request object that describes how to load data via direct SQL DML.  
        /// This API can be used with an IDO by assuring the given column names match the corresponding property names.
        /// </summary>
        /// <param name="columnExpressionByColumnName">
        /// For each column name in the result set, give the necessary SQL expression.  
        /// This API can be used with an IDO by assuring the given column names match the corresponding property names.
        /// </param>
        /// <param name="tableName">The name of the table to load data from.</param>
        /// <param name="loadForChange"> When false, returns a result set that cannot be altered.</param>
        /// <param name="lockingType"> This flag will add lock to primary table</param>
        /// <param name="fromClause">Optional.  The parameterized from clause, including any joins, to use.</param>
        /// <param name="whereClause">Optional.  The parameterized where clause to use.</param>
        /// <param name="orderByClause">Optional.  The order-by clause to use.</param>
        /// <param name="maximumRows">Optional.  The maximum number of records to load.  Use zero for no limit.</param>
        /// <returns></returns>
        ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<string, string> columnExpressionByColumnName,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null,
            IParameterizedCommand orderByClause = null,
            int? maximumRows = 0,
            string targetTableName = null);

        /// <summary>
        /// Create an load request object that describes how to load data via direct SQL DML.  
        /// This API cannot be used with an IDO.
        /// </summary>
        /// <param name="columnExpressionByVariableToAssign">For each variable that implements IUDDTType, give the necessary SQL expression.</param>
        /// <param name="tableName">The name of the table to load data from.</param>
        /// <param name="loadForChange"> When false, returns a result set that cannot be altered.</param>
        /// <param name="lockingType"> This flag will add lock to primary table</param>
        /// <param name="fromClause">Optional.  The parameterized from clause, including any joins, to use.</param>
        /// <param name="whereClause">Optional.  The parameterized where clause to use.</param>
        /// <param name="orderByClause">Optional.  The order-by clause to use.</param>
        /// <param name="maximumRows">Optional.  The maximum number of records to load.  Use zero for no limit.</param>
        /// <returns></returns>
        ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, string> columnExpressionByVariableToAssign,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null,
            IParameterizedCommand orderByClause = null,
            int? maximumRows = 0,
            string targetTableName = null);

        /// <summary>
        /// Create an load request object that describes how to load data via direct SQL DML.  
        /// This API can be used with an IDO by assuring the given column names match the corresponding property names.
        /// </summary>
        /// <param name="columnNameAndExpressionByVariableToAssign">
        /// For each variable that implements IUDDTType, give a column name for the result set and the necessary SQL expression.
        /// This API can be used with an IDO by assuring the given column names match the corresponding property names.
        /// </param>
        /// <param name="tableName">The name of the table to load data from.</param>
        /// <param name="loadForChange"> When false, returns a result set that cannot be altered.</param>
        /// <param name="lockingType">Optional. This flag will add lock to primary table</param>
        /// <param name="fromClause">Optional.  The parameterized from clause, including any joins, to use.</param>
        /// <param name="whereClause">Optional.  The parameterized where clause to use.</param>
        /// <param name="orderByClause">Optional.  The order-by clause to use.</param>
        /// <param name="maximumRows">Optional.  The maximum number of records to load.  Use zero for no limit.</param>
        /// <returns></returns>
        ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null,
            IParameterizedCommand orderByClause = null,
            int? maximumRows = 0,
            string targetTableName = null);

        /// <summary>
        /// Create an load request object that describes how to load data via direct SQL DML.  
        /// This API can be used with an IDO by assuring the given column names match the corresponding property names.
        /// </summary>
        /// <param name="columnParametizedByColumnName">
        /// For each column name in the result set, give the necessary SQL expression.  
        /// This API can be used with an IDO by assuring the given column names match the corresponding property names.
        /// </param>
        /// <param name="tableName">The name of the table to load data from.</param>
        /// <param name="loadForChange"> When false, returns a result set that cannot be altered.</param>
        /// <param name="lockingType"> This flag will add lock to primary table</param>
        /// <param name="fromClause">Optional.  The parameterized from clause, including any joins, to use.</param>
        /// <param name="whereClause">Optional.  The parameterized where clause to use.</param>
        /// <param name="orderByClause">Optional.  The order-by clause to use.</param>
        /// <param name="maximumRows">Optional.  The maximum number of records to load.  Use zero for no limit.</param>
        /// <returns></returns>
        ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null,
            IParameterizedCommand orderByClause = null,
            int? maximumRows = 0,
            string targetTableName = null);

        ICollectionLoadRequest SQLLoad(
           IReadOnlyDictionary<IUDDTType, IParameterizedCommand> columnParametizedByVariableToAssign,
           string tableName,
           bool loadForChange,
           LockingType lockingType,
           IParameterizedCommand fromClause = null,
           IParameterizedCommand whereClause = null,
           IParameterizedCommand orderByClause = null,
           int? maximumRows = 0,
           string targetTableName = null);

        /// <summary>
        /// Creates a clause for the collection load request that will automatically protect parameters from injection attack by using SQL Parameters.
        /// Looks like: loadCollectionRequestFactory.Clause("itw.item = {0} and itw.whse = {1}", Item, Whse)
        /// Do NOT use FormatLiteral() or other string based parameter handling.
        /// </summary>
        /// <param name="clauseTemplate">
        /// The clause template indicating where parameters are positioned.
        /// Looks like: "itw.item = {0} and itw.whse = {1}"
        /// </param>
        /// <param name="clauseParameters">
        /// The list of positional parameters to use in the where clause.
        /// </param>
        /// <returns></returns>
        IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters);
    }
}
