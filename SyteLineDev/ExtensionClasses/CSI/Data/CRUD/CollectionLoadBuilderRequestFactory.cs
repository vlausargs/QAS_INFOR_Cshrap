using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionLoadBuilderRequestFactory : ICollectionLoadBuilderRequestFactory
    {
        readonly IQueryLanguage queryLanguage;

        public CollectionLoadBuilderRequestFactory(IQueryLanguage queryLanguage)
        {
            this.queryLanguage = queryLanguage;
        }

        public ICollectionLoadBuilderRequest Create(IReadOnlyDictionary<string, object> columnExpressionByColumnName)
        {
            return CollectionLoadBuilderRequest.Create(columnExpressionByColumnName);
        }

        public ICollectionLoadBuilderRequest Create(
            IReadOnlyDictionary<IUDDTType, string> columnExpressionByVariableToAssign)
        {
            //We have variables and expressions, but not column names.  Generate some.
            var columnNameAndExpressionByVariableToAssign = new Dictionary<IUDDTType, IEnumerable<string>>();
            int i = 0;
            foreach (var pair in columnExpressionByVariableToAssign)
            {
                var columnName = i++.ToString();
                columnNameAndExpressionByVariableToAssign[pair.Key] = new[] { columnName, pair.Value };
            }

            return CollectionLoadBuilderRequest.Create(columnNameAndExpressionByVariableToAssign);
        }

        public ICollectionLoadBuilderRequest Create(IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName)
        {
            return CollectionLoadBuilderRequest.Create(columnParametizedByColumnName);
        }

        public IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters)
        {
            return queryLanguage.WhereClause(clauseTemplate, clauseParameters);
        }
    }
}
