using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionLoadBuilderRequest : ICollectionLoadBuilderRequest
    {
        public IEnumerable<string> RequestedColumns { get; }

        public IReadOnlyDictionary<string, object> ColumnExpressionByColumnName { get; }

        public IReadOnlyDictionary<IUDDTType, string> ColumnNameByVariableToAssign { get; }

        public IReadOnlyDictionary<string, IParameterizedCommand> ColumnParametizedByColumnName { get; }

        public CollectionLoadBuilderRequest(
            IReadOnlyDictionary<string, object> columnExpressionByColumnName,
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            IEnumerable<string> requestedColumns)
        {
            ColumnExpressionByColumnName = columnExpressionByColumnName;
            ColumnNameByVariableToAssign = columnNameByVariableToAssign;
            ColumnParametizedByColumnName = columnParametizedByColumnName;
            RequestedColumns = requestedColumns;
        }

        public static ICollectionLoadBuilderRequest Create(IReadOnlyDictionary<string, object> columnExpressionByColumnName)
        {
            var requestedColumns = columnExpressionByColumnName.Keys;
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            return new CollectionLoadBuilderRequest(columnExpressionByColumnName, columnNameByVariableToAssign, columnParametizedByColumnName, requestedColumns);
        }

        public static ICollectionLoadBuilderRequest Create(
            IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign)
        {
            var requestedColumns = RequestedColumnsFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnExpressionByColumnName = ColumnExpressionByColumnNameFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnNameByVariableToAssign = ColumnNameByVariableToAssignFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            return new CollectionLoadBuilderRequest(columnExpressionByColumnName, columnNameByVariableToAssign, columnParametizedByColumnName, requestedColumns);
        }

        public static ICollectionLoadBuilderRequest Create(IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName)
        {
            var requestedColumns = columnParametizedByColumnName.Keys;
            var columnExpressionByColumnName = new Dictionary<string, object>();
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            return new CollectionLoadBuilderRequest(columnExpressionByColumnName, columnNameByVariableToAssign, columnParametizedByColumnName, requestedColumns);
        }

        static IEnumerable<string> RequestedColumnsFromColumnNameAndExpressionByVariableToAssign(IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign)
        {
            var nonDistinctRequestedColumns = columnNameAndExpressionByVariableToAssign.Values.Select(v => v.ElementAt(0));
            var requestedColumns = nonDistinctRequestedColumns.Distinct();
            Contract.Requires<ArgumentException>(requestedColumns.Count() == nonDistinctRequestedColumns.Count(), "duplicate columns"); //make sure there's no duplicates

            return requestedColumns;
        }

        static Dictionary<string, object> ColumnExpressionByColumnNameFromColumnNameAndExpressionByVariableToAssign(IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign)
        {
            var columnExpressionByColumnName = new Dictionary<string, object>();
            foreach (var pair in columnNameAndExpressionByVariableToAssign)
            {
                columnExpressionByColumnName.Add(pair.Value.ElementAt(0), pair.Value.ElementAt(1));
            }
            return columnExpressionByColumnName;
        }

        static Dictionary<IUDDTType, string> ColumnNameByVariableToAssignFromColumnNameAndExpressionByVariableToAssign(IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign)
        {
            return columnNameAndExpressionByVariableToAssign.ToDictionary(p => p.Key, p => p.Value.ElementAt(0));
        }
    }
}
