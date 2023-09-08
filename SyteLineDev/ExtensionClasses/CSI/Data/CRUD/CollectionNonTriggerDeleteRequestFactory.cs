using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerDeleteRequestFactory : ICollectionNonTriggerDeleteRequestFactory
    {
        IQueryLanguage queryLanguage;

        public CollectionNonTriggerDeleteRequestFactory(IQueryLanguage queryLanguage)
        {
            this.queryLanguage = queryLanguage ?? throw new ArgumentNullException(nameof(queryLanguage));
        }

        public ICollectionNonTriggerDeleteRequest SQLDelete(
            string tableName,
            int? maximumRows = 0,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null)
        {
            return CollectionNonTriggerDeleteRequest.SQLDelete(tableName, maximumRows, fromClause, whereClause);
        }

        public IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters)
        {
            return queryLanguage.WhereClause(clauseTemplate, clauseParameters);
        }

    }
}
