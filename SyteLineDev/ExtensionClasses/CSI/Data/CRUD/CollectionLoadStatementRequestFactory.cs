using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionLoadStatementRequestFactory : ICollectionLoadStatementRequestFactory
    {
        readonly IQueryLanguage queryLanguage;

        public CollectionLoadStatementRequestFactory(IQueryLanguage queryLanguage)
        {
            this.queryLanguage = queryLanguage;
        }

        public ICollectionLoadStatementRequest SQLLoad(IReadOnlyDictionary<IUDDTType, string> columnExpressionByVariableToAssign, 
            IParameterizedCommand selectStatement, 
            string targetTableName)
        {
            var columnNameAndExpressionByVariableToAssign = new Dictionary<IUDDTType, IEnumerable<string>>();
            int i = 0;
            foreach (var pair in columnExpressionByVariableToAssign)
            {
                var columnName = i++.ToString();
                columnNameAndExpressionByVariableToAssign[pair.Key] = new[] { columnName, pair.Value };
            }

            return CollectionLoadStatementRequest.SQLLoad(columnNameAndExpressionByVariableToAssign, selectStatement, targetTableName);
        }

        public ICollectionLoadStatementRequest SQLLoad(IEnumerable<string> columns, 
            IParameterizedCommand selectStatement, 
            string targetTableName)
        {
            var columnExpressionByColumnName = columns.ToDictionary(c => c, c => c);
            return CollectionLoadStatementRequest.SQLLoad(columnExpressionByColumnName, selectStatement, targetTableName);
        }

        public ICollectionLoadStatementRequest SQLLoad(IReadOnlyDictionary<string, string> columnExpressionByColumnName, 
            IParameterizedCommand selectStatement, 
            string targetTableName)
        {
            return CollectionLoadStatementRequest.SQLLoad(columnExpressionByColumnName, selectStatement, targetTableName);
        }

        public ICollectionLoadStatementRequest SQLLoad(IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign, 
            IParameterizedCommand selectStatement, 
            string targetTableName)
        {
            return CollectionLoadStatementRequest.SQLLoad(columnNameAndExpressionByVariableToAssign, selectStatement, targetTableName);
        }

        public ICollectionLoadStatementRequest SQLLoad(IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            IParameterizedCommand selectStatement,
            string targetTableName = null)
        {
            return CollectionLoadStatementRequest.SQLLoad(columnParametizedByColumnName, selectStatement, targetTableName);
        }

        public ICollectionLoadStatementRequest SQLLoad(IReadOnlyDictionary<IUDDTType, IParameterizedCommand> columnParametizedByVariableToAssign,
            IParameterizedCommand selectStatement,
            string targetTableName = null)
        {
            //We have variables and expressions, but not column names.  Generate some.
            var columnParameterByVariableToAssign = new Dictionary<IUDDTType, Dictionary<string, IParameterizedCommand>>();
            int i = 0;
            foreach (var pair in columnParametizedByVariableToAssign)
            {
                var columnName = i++.ToString();
                var values = new Dictionary<string, IParameterizedCommand>() { { columnName, pair.Value } };
                columnParameterByVariableToAssign.Add(pair.Key, values);
            }

            return CollectionLoadStatementRequest.SQLLoad(columnParameterByVariableToAssign, selectStatement, targetTableName);
        }

        public IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters)
        {
            return queryLanguage.WhereClause(clauseTemplate, clauseParameters);
        }
    }
}
