using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadStatementRequestFactory
    {
        /// <summary>
        /// Gets the list of columns of the select statement.
        /// </summary>
        /// <param name="columns">List of Columns</param>
        /// <param name="selectStatement">
        /// Sample: collectionLoadRequestFactory.Clause("SELECT @selectList FROM TABLE WHERE columnName1 = {0} and columnName2 = {1}", param1, param2)
        /// Where @selectList is the list of columns declared.</param>
        /// <returns></returns>
        ICollectionLoadStatementRequest SQLLoad(
            IEnumerable<string> columns,
            IParameterizedCommand selectStatement,
            string targetTableName = null);

        /// <summary>
        /// Gets the list of columns and expressions.
        /// </summary>
        /// <param name="columnExpressionByColumnName">The Dictionary of column expression/column name together with its alias
        /// Looks like: { "alias", "expression/column name"}</param>
        /// <param name="selectStatement">
        /// Sample: collectionLoadRequestFactory.Clause("SELECT @selectList FROM TABLE WHERE columnName1 = {0} and columnName2 = {1}", param1, param2)
        /// Where @selectList is the list of columns declared in the Dictionary.</param>
        /// <returns></returns>
        ICollectionLoadStatementRequest SQLLoad(
            IReadOnlyDictionary<string, string> columnExpressionByColumnName,
            IParameterizedCommand selectStatement,
            string targetTableName = null);

        /// <summary>
        /// Assigns the UDDT Variable with the column value of sql statement. Automatically protects parameters from SQL Injection using SQL Parameters.
        /// </summary>
        /// <param name="columnExpressionByVariableToAssign">The list of uddt variables partnered with the corresponding column of select</param>
        /// <param name="selectStatement">
        /// Sample: collectionLoadRequestFactory.Clause("SELECT @selectList FROM TABLE WHERE columnName1 = {0} and columnName2 = {1}", param1, param2)
        /// Where @selectList is the list of columns declared in the Dictionary.</param>
        /// <returns></returns>
        ICollectionLoadStatementRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, string> columnExpressionByVariableToAssign,
            IParameterizedCommand selectStatement,
            string targetTableName = null);

        ICollectionLoadStatementRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign,
            IParameterizedCommand selectStatement,
            string targetTableName = null);

        /// <summary>
        /// Gets the list of columns and expressions.
        /// </summary>
        /// <param name="columnParametizedByColumnName">The Dictionary of column expression/column name together with its alias
        /// Looks like: { "alias", collectionLoadRequestFactory.Clause("statement", parameter) }</param>
        /// <param name="selectStatement">
        /// Sample: collectionLoadRequestFactory.Clause("SELECT @selectList FROM TABLE WHERE columnName1 = {0} and columnName2 = {1}", param1, param2)
        /// Where @selectList is the list of columns declared in the Dictionary.</param>
        /// <returns></returns>
        ICollectionLoadStatementRequest SQLLoad(
            IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            IParameterizedCommand selectStatement,
            string targetTableName = null);
      
        ICollectionLoadStatementRequest SQLLoad(IReadOnlyDictionary<IUDDTType, IParameterizedCommand> columnParametizedByVariableToAssign,
            IParameterizedCommand selectStatement,
            string targetTableName = null);

        IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters);
    }
}
