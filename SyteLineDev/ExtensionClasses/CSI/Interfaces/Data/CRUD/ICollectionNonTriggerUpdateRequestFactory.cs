using CSI.Data.SQL;
using System.Collections.Generic;

namespace CSI.Data.CRUD
{
    public interface ICollectionNonTriggerUpdateRequestFactory
    {
        /// <summary>
        /// Use ICollectionNonTriggerUpdateRequest.SQLUpdate to issue an update command without the need to load data prior to update.
        /// Data from joined tables can be used to set column values into the target table.
        /// It should only be used for CRUD operations involving tables without triggers e.g. temp tables, some staging tables.
        /// </summary>
        /// <param name="tableName">Target table name</param>
        /// <param name="expressionByColumnToAssign">Dictionary of column name and column value or expression (parameterized command) to assign</param>
        /// <param name="maximumRows">Maximum rows (i.e. TOP clause)</param>
        /// <param name="fromClause">Parameterized command for the from clause, may contain join clauses</param>
        /// <param name="whereClause">Parameterized Where clause</param>
        /// <returns>ICollectionNonTriggerUpdateRequest: Use appDB.UpdateWithoutTrigger to execute the request</returns>
        ICollectionNonTriggerUpdateRequest SQLUpdate(string tableName,
                                                     IReadOnlyDictionary<string, IParameterizedCommand> expressionByColumnToAssign = null,
                                                     int? maximumRows = 0,
                                                     IParameterizedCommand fromClause = null,
                                                     IParameterizedCommand whereClause = null);

        IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters);
    }
}