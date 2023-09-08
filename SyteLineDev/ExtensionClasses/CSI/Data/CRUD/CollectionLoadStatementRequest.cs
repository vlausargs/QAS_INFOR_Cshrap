using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionLoadStatementRequest : ICollectionLoadStatementRequest
    {
        public IParameterizedCommand SelectStatement { get; }

        public IEnumerable<string> RequestedColumns { get; }

        public IReadOnlyDictionary<string, string> ColumnExpressionByColumnName { get; } //Column names MUST match the IDO Property Names

        public IReadOnlyDictionary<IUDDTType, string> ColumnNameByVariableToAssign { get; } //Column names MUST match the IDO Property Names
       
        public IReadOnlyDictionary<string, IParameterizedCommand> ColumnParametizedByColumnName { get; } //Column names MUST match the IDO Property Names

        public IReadOnlyDictionary<IUDDTType, IParameterizedCommand> ColumnParametizedByVariableToAssign { get; } //Column names MUST match the IDO Property Names


        public string TargetTableName { get; }

        CollectionLoadStatementRequest(
            IParameterizedCommand selectStatement,
            IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, string> columnExpressionByColumnName,
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            IReadOnlyDictionary<IUDDTType, IParameterizedCommand> columnParametizedByVariableToAssign,
            string targetTableName)
        {
            this.SelectStatement = selectStatement;
            this.RequestedColumns = requestedColumns;
            this.ColumnExpressionByColumnName = columnExpressionByColumnName;
            this.ColumnNameByVariableToAssign = columnNameByVariableToAssign;
            this.ColumnParametizedByColumnName = columnParametizedByColumnName;
            this.ColumnParametizedByVariableToAssign = columnParametizedByVariableToAssign;
            this.TargetTableName = targetTableName;
        }

        public static ICollectionLoadStatementRequest SQLLoad(
             IReadOnlyDictionary<string, string> columnExpressionByColumnName,
             IParameterizedCommand selectStatement,
             string targetTableName)
        {
            var requestedColumns = columnExpressionByColumnName.Keys;
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            var columnParametizedByVariableToAssign = new Dictionary<IUDDTType, IParameterizedCommand>();

            return new CollectionLoadStatementRequest(selectStatement, 
                requestedColumns, 
                columnExpressionByColumnName, 
                columnNameByVariableToAssign, 
                columnParametizedByColumnName,
                columnParametizedByVariableToAssign,
                targetTableName);
        }

        public static ICollectionLoadStatementRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign,
            IParameterizedCommand selectStatement,
            string targetTableName)
        {
            var requestedColumns = RequestedColumnsFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnExpressionByColumnName = ColumnExpressionByColumnNameFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnNameByVariableToAssign = ColumnNameByVariableToAssignFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            var columnParametizedByVariableToAssign = new Dictionary<IUDDTType, IParameterizedCommand>();

            return new CollectionLoadStatementRequest(selectStatement, 
                requestedColumns, 
                columnExpressionByColumnName, 
                columnNameByVariableToAssign, 
                columnParametizedByColumnName,
                columnParametizedByVariableToAssign,
                targetTableName);
        }

        public static ICollectionLoadStatementRequest SQLLoad(
            IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            IParameterizedCommand selectStatement,
            string targetTableName)
        {
            var requestedColumns = columnParametizedByColumnName.Keys;
            var columnExpressionByColumnName = new Dictionary<string, string>();
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            var columnParametizedByVariableToAssign = new Dictionary<IUDDTType, IParameterizedCommand>();

            return new CollectionLoadStatementRequest(selectStatement, 
                requestedColumns, 
                columnExpressionByColumnName, 
                columnNameByVariableToAssign, 
                columnParametizedByColumnName,
                columnParametizedByVariableToAssign,
                targetTableName);
        }

        public static ICollectionLoadStatementRequest SQLLoad(
           IReadOnlyDictionary<IUDDTType, Dictionary<string, IParameterizedCommand>> columnParametizedByVariableToAssign,
           IParameterizedCommand selectStatement,
           string targetTableName)
        {
            var requestedColumns = columnParametizedByVariableToAssign.Values.Select(v => v.ElementAt(0).Key);
            var columnExpressionByColumnName = new Dictionary<string, string>();
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            var columnParametizedByVariableToAssignValues = new Dictionary<IUDDTType, IParameterizedCommand>();


            columnParametizedByColumnName = columnParametizedByVariableToAssign.ToDictionary(p => p.Value.ElementAt(0).Key, p => p.Value.ElementAt(0).Value);
            columnParametizedByVariableToAssignValues = columnParametizedByVariableToAssign.ToDictionary(p => p.Key, p => p.Value.ElementAt(0).Value);

            return new CollectionLoadStatementRequest(selectStatement, 
                requestedColumns, 
                columnExpressionByColumnName, 
                columnNameByVariableToAssign, 
                columnParametizedByColumnName,
                columnParametizedByVariableToAssignValues,
                targetTableName);
        }

        static IEnumerable<string> RequestedColumnsFromColumnNameAndExpressionByVariableToAssign(IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign)
        {
            var nonDistinctRequestedColumns = columnNameAndExpressionByVariableToAssign.Values.Select(v => v.ElementAt(0));
            var requestedColumns = nonDistinctRequestedColumns.Distinct();
            Contract.Requires<ArgumentException>(requestedColumns.Count() == nonDistinctRequestedColumns.Count(), "duplicate columns"); //make sure there's no duplicates

            return requestedColumns;
        }

        static Dictionary<string, string> ColumnExpressionByColumnNameFromColumnNameAndExpressionByVariableToAssign(IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign)
        {
            var columnExpressionByColumnName = new Dictionary<string, string>();
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
