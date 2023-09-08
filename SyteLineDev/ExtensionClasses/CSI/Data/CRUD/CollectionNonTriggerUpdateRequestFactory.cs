using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerUpdateRequestFactory : ICollectionNonTriggerUpdateRequestFactory
    {
        IQueryLanguage queryLanguage;

        public CollectionNonTriggerUpdateRequestFactory(IQueryLanguage queryLanguage)
        {
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
        }

        public ICollectionNonTriggerUpdateRequest SQLUpdate(
            string tableName,
            IReadOnlyDictionary<string, IParameterizedCommand> expressionByColumnToAssign,
            int? maximumRows,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause)
        {
            return CollectionNonTriggerUpdateRequest.SQLUpdate(tableName, expressionByColumnToAssign, maximumRows, fromClause, whereClause);
        }

        public IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters)
        {
            return queryLanguage.WhereClause(clauseTemplate, clauseParameters);
        }

    }
}
