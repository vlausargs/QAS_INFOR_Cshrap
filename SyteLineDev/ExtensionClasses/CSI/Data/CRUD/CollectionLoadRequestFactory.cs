using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSI.Data.SQL;

namespace CSI.Data.CRUD
{
    public class CollectionLoadRequestFactory : ICollectionLoadRequestFactory
    {
        readonly IQueryLanguage queryLanguage;

        public CollectionLoadRequestFactory(IQueryLanguage queryLanguage)
        {
            this.queryLanguage = queryLanguage;
        }

        public ICollectionLoadRequest SQLLoad(
            IEnumerable<string> columns,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            string targetTableName)
        {
            var columnExpressionByColumnName = columns.ToDictionary(c => c, c => c);
            return CollectionLoadRequest.SQLLoad(columnExpressionByColumnName, tableName, fromClause, whereClause, orderByClause, maximumRows, loadForChange, targetTableName, lockingType);
        }

        public ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<string, string> columnExpressionsByColumnName,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            string targetTableName)
        {
            return CollectionLoadRequest.SQLLoad(columnExpressionsByColumnName, tableName, fromClause, whereClause, orderByClause, maximumRows, loadForChange, targetTableName, lockingType);
        }

        public ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, string> columnExpressionByVariableToAssign,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            string targetTableName)
        {
            //We have variables and expressions, but not column names.  Generate some.
            var columnNameAndExpressionByVariableToAssign = new Dictionary<IUDDTType, IEnumerable<string>>();
            int i = 0;
            foreach (var pair in columnExpressionByVariableToAssign)
            {
                var columnName = i++.ToString();
                columnNameAndExpressionByVariableToAssign[pair.Key] = new[] { columnName, pair.Value };
            }

            return CollectionLoadRequest.SQLLoad(columnNameAndExpressionByVariableToAssign, tableName, fromClause, whereClause, orderByClause, maximumRows, loadForChange, targetTableName, lockingType);
        }

        public ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            string targetTableName)
        {
            return CollectionLoadRequest.SQLLoad(columnNameAndExpressionByVariableToAssign, tableName, fromClause, whereClause, orderByClause, maximumRows, loadForChange, targetTableName, lockingType);
        }

        public ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            string tableName,
            bool loadForChange,
            LockingType lockingType,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            string targetTableName)
        {
            return CollectionLoadRequest.SQLLoad(columnParametizedByColumnName, tableName, fromClause, whereClause, orderByClause, maximumRows, loadForChange, targetTableName, lockingType);
        }

        public ICollectionLoadRequest SQLLoad(
           IReadOnlyDictionary<IUDDTType, IParameterizedCommand> columnParametizedByVariableToAssign,
           string tableName,
           bool loadForChange,
           LockingType lockingType,
           IParameterizedCommand fromClause,
           IParameterizedCommand whereClause,
           IParameterizedCommand orderByClause,
           int? maximumRows,
           string targetTableName)
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

            return CollectionLoadRequest.SQLLoad(columnParameterByVariableToAssign, tableName, fromClause, whereClause, orderByClause, maximumRows, loadForChange, targetTableName, lockingType);
        }

        public IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters)
        {
            return queryLanguage.WhereClause(clauseTemplate, clauseParameters);
        }
    }
}
