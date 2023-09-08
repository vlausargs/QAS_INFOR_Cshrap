using CSI.Data.SQL;
using System.Collections.Generic;

namespace CSI.Data.CRUD
{
    public interface ICollectionNonTriggerInsertRequestFactory
    {
        IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters);

        /// <summary>
        /// Use ICollectionNonTriggerInsertRequest.SQLInsert to issue an insert command without the need to load data prior to insert.
        /// Data from joined tables can be used to insert into the target table.
        /// It should only be used for CRUD operations involving tables without triggers e.g. temp tables, some staging tables.
        /// </summary>
        /// <param name="targetTableName">Target table name</param>
        /// <param name="targetColumns">Column names to insert data to</param>
        /// <param name="valuesByExpressionToAssign">Dictionary of column name and column value or expression (parameterized command) to assign</param>
        /// <param name="maximumRows">Maximum rows (i.e. TOP clause)</param>
        /// <param name="fromClause">Parameterized command for the from clause, may contain join clauses</param>
        /// <param name="whereClause">Parameterized Where clause</param>
        /// <param name="orderByClause">Parameterized Order by clause</param>
        /// <param name="distinct">Select distinct rows for insert</param>
        /// <returns>ICollectionNonTriggerInsertRequest: Use appDB.InsertWithoutTrigger to execute the request</returns>
        ICollectionNonTriggerInsertRequest SQLInsert(string targetTableName,
                                                     List<string> targetColumns,
                                                     IReadOnlyDictionary<string, IParameterizedCommand> valuesByExpressionToAssign,
                                                     int? maximumRows = 0,
                                                     IParameterizedCommand fromClause = null,
                                                     IParameterizedCommand whereClause = null,
                                                     IParameterizedCommand orderByClause = null,
                                                     bool distinct = false);
    }
}