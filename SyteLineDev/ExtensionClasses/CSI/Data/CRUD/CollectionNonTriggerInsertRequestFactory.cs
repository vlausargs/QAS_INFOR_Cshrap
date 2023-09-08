using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerInsertRequestFactory : ICollectionNonTriggerInsertRequestFactory
    {
        IQueryLanguage queryLanguage;

        public CollectionNonTriggerInsertRequestFactory(IQueryLanguage queryLanguage)
        {
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
        }

        public ICollectionNonTriggerInsertRequest SQLInsert(
            string targetTableName,
            List<string> targetColumns,
            IReadOnlyDictionary<string, IParameterizedCommand> valuesByExpressionToAssign,
            int? maximumRows,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            bool distinct)
        {
            return CollectionNonTriggerInsertRequest.SQLInsert(targetTableName, targetColumns, valuesByExpressionToAssign, maximumRows, fromClause, whereClause, orderByClause, distinct);
        }

        public IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters)
        {
            return queryLanguage.WhereClause(clauseTemplate, clauseParameters);
        }

    }
}
