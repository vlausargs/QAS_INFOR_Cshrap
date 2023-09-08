using CSI.Data.SQL;

namespace CSI.Data.CRUD
{
    public interface ICollectionNonTriggerDeleteRequestFactory
    {
        IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters);

        /// <summary>
        /// Use ICollectionNonTriggerDeleteRequest.SQLDelete to issue a delete command without the need to load data prior to delete.
        /// It should only be used for CRUD operations involving tables without triggers e.g. temp tables, some staging tables.
        /// </summary>
        /// <param name="tableName">Target table name</param>
        /// <param name="maximumRows">Maximum rows (i.e. TOP clause)</param>
        /// <param name="fromClause">Parameterized command for the from clause, may contain join clauses</param>
        /// <param name="whereClause">Parameterized Where clause</param>
        /// <returns>ICollectionNonTriggerDeleteRequest: Use appDB.DeleteWithoutTrigger to execute the request</returns>
        ICollectionNonTriggerDeleteRequest SQLDelete(string tableName,
                                                     int? maximumRows = 0,
                                                     IParameterizedCommand fromClause = null,
                                                     IParameterizedCommand whereClause = null);
    }
}