using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSI.Data.CRUD
{
    public class CollectionLoadRequest : ICollectionLoadRequest
    {
        //Mongoose ==============================================================
        public string IDOName { get; private set; }

        public string IDOWhereClause { get; private set; }

        public string IDOOrderByClause { get; private set; }

        //SQL ====================================================================

        public string TableName { get; }

        public string TargetTableName { get; }

        public IParameterizedCommand FromClause { get; }

        public IParameterizedCommand WhereClause { get; }

        public IParameterizedCommand OrderByClause { get; }

        //Both ====================================================================
        public IEnumerable<string> RequestedColumns { get; }

        public IReadOnlyDictionary<string, string> ColumnExpressionByColumnName { get; } //Column names MUST match the IDO Property Names

        public IReadOnlyDictionary<IUDDTType, string> ColumnNameByVariableToAssign { get; } //Column names MUST match the IDO Property Names

        public IReadOnlyDictionary<string, IParameterizedCommand> ColumnParametizedByColumnName { get; } //Column names MUST match the IDO Property Names

        public IReadOnlyDictionary<IUDDTType, IParameterizedCommand> ColumnParametizedByVariableToAssign { get; } //Column names MUST match the IDO Property Names

        public int MaximumRows { get; }

        public bool LoadForChange { get; }
        //=========================================================================
        public LockingType LockingType { get; }
        public bool CanIDO => !string.IsNullOrWhiteSpace(IDOName);

        public bool CanSQL => !string.IsNullOrWhiteSpace(TableName);

        CollectionLoadRequest(
            string tableName,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            IEnumerable<string> requestedColumns,
            IReadOnlyDictionary<string, string> columnExpressionByColumnName,
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
            IReadOnlyDictionary<IUDDTType, IParameterizedCommand> columnParametizedByVariableToAssign,
            int? maximumRows,
            bool loadForChange,
            string targetTableName,
            LockingType lockingType)
        {
            this.TableName = tableName;
            this.TargetTableName = targetTableName;
            this.FromClause = fromClause;
            this.WhereClause = whereClause;
            this.OrderByClause = orderByClause;
            this.MaximumRows = maximumRows ?? 0;
            this.LoadForChange = loadForChange;
            this.RequestedColumns = requestedColumns;
            this.ColumnExpressionByColumnName = columnExpressionByColumnName;
            this.ColumnNameByVariableToAssign = columnNameByVariableToAssign;
            this.ColumnParametizedByColumnName = columnParametizedByColumnName;
            this.ColumnParametizedByVariableToAssign = columnParametizedByVariableToAssign;
            this.LockingType = lockingType;
            Contract.Requires<ArgumentNullException>(requestedColumns != null, "requestedColumns must be specified");
            Contract.Requires<ArgumentNullException>(columnExpressionByColumnName != null, "columnExpressionByColumnName must be specified");
            Contract.Requires<ArgumentNullException>(columnNameByVariableToAssign != null, "columnNameByVariableToAssign must be specified");
            Contract.Requires<ArgumentNullException>(columnParametizedByColumnName != null, "ColumnParametizedByColumnName must be specified");

            Contract.Requires<ArgumentNullException>(TableName != null, "tableName must be specified");
            Contract.Requires<ArgumentNullException>(FromClause != null, "fromClause must be specified");

            Contract.Requires<ArgumentOutOfRangeException>(maximumRows >= 0, "maximumRows may not be less than zero");

            Contract.Requires<ArgumentOutOfRangeException>(RequestedColumns.Count() > 0, "at least one column must be requested");

            Contract.Requires<ArgumentException>(this.CanIDO || this.CanSQL, "the request can't be used for SQL or IDO");
            //Contract.Requires<ArgumentException>(this.CanSQL, "the request can't be used for SQL");

        }

        public ICollectionLoadRequest AddIDOIntercept(
            string idoName,
            string idoWhereClause,
            string idoOrderByClause)
        {
            Contract.Requires<ArgumentNullException>(idoName != null, "idoName must be specified");

            this.IDOName = idoName;
            this.IDOWhereClause = idoWhereClause;
            this.IDOOrderByClause = idoOrderByClause;

            return this;
        }

        public static ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<string, string> columnExpressionByColumnName,
            string tableName,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            bool loadForChange,
            string targetTableName,
            LockingType lockingType)
        {
            var requestedColumns = columnExpressionByColumnName.Keys;
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            var columnParametizedByVariableToAssign = new Dictionary<IUDDTType, IParameterizedCommand>();

            return new CollectionLoadRequest(tableName,
                fromClause,
                whereClause,
                orderByClause,
                requestedColumns,
                columnExpressionByColumnName,
                columnNameByVariableToAssign,
                columnParametizedByColumnName,
                columnParametizedByVariableToAssign,
                maximumRows,
                loadForChange,
                targetTableName,
                lockingType);
        }

        public static ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign,
            string tableName,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            bool loadForChange,
            string targetTableName,
            LockingType lockingType)
        {
            var requestedColumns = RequestedColumnsFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnExpressionByColumnName = ColumnExpressionByColumnNameFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnNameByVariableToAssign = ColumnNameByVariableToAssignFromColumnNameAndExpressionByVariableToAssign(columnNameAndExpressionByVariableToAssign);
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            var columnParametizedByVariableToAssign = new Dictionary<IUDDTType, IParameterizedCommand>();

            return new CollectionLoadRequest(tableName,
                fromClause,
                whereClause,
                orderByClause,
                requestedColumns,
                columnExpressionByColumnName,
                columnNameByVariableToAssign,
                columnParametizedByColumnName,
                columnParametizedByVariableToAssign,
                maximumRows,
                loadForChange,
                targetTableName,
                lockingType);
        }

        public static ICollectionLoadRequest SQLLoad(
             IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName,
             string tableName,
             IParameterizedCommand fromClause,
             IParameterizedCommand whereClause,
             IParameterizedCommand orderByClause,
             int? maximumRows,
             bool loadForChange,
             string targetTableName,
             LockingType lockingType)
        {
            var requestedColumns = columnParametizedByColumnName.Keys;

            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            var columnExpressionByColumnName = new Dictionary<string, string>();
            var columnParametizedByVariableToAssign = new Dictionary<IUDDTType, IParameterizedCommand>();

            return new CollectionLoadRequest(tableName,
                fromClause,
                whereClause,
                orderByClause,
                requestedColumns,
                columnExpressionByColumnName,
                columnNameByVariableToAssign,
                columnParametizedByColumnName,
                columnParametizedByVariableToAssign,
                maximumRows,
                loadForChange,
                targetTableName,
                lockingType);
        }

        public static ICollectionLoadRequest SQLLoad(
            IReadOnlyDictionary<IUDDTType, Dictionary<string, IParameterizedCommand>> columnParametizedByVariableToAssign,
            string tableName,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            int? maximumRows,
            bool loadForChange,
            string targetTableName,
            LockingType lockingType)
        {
            var requestedColumns = columnParametizedByVariableToAssign.Values.Select(v => v.ElementAt(0).Key);
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            var columnExpressionByColumnName = new Dictionary<string, string>();
            var columnParametizedByColumnName = new Dictionary<string, IParameterizedCommand>();
            var columnParametizedByVariableToAssignValues = new Dictionary<IUDDTType, IParameterizedCommand>();


            columnParametizedByColumnName = columnParametizedByVariableToAssign.ToDictionary(p => p.Value.ElementAt(0).Key, p => p.Value.ElementAt(0).Value);
            columnParametizedByVariableToAssignValues = columnParametizedByVariableToAssign.ToDictionary(p => p.Key, p => p.Value.ElementAt(0).Value);
            columnNameByVariableToAssign = ColumnExpressionByColumnNameFromColumnNameAndExpressionByVariableToAssign(columnParametizedByVariableToAssignValues);

            return new CollectionLoadRequest(tableName,
                fromClause,
                whereClause,
                orderByClause,
                requestedColumns,
                columnExpressionByColumnName,
                columnNameByVariableToAssign,
                columnParametizedByColumnName,
                columnParametizedByVariableToAssignValues,
                maximumRows,
                loadForChange,
                targetTableName,
                lockingType);
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

        static Dictionary<IUDDTType, string> ColumnExpressionByColumnNameFromColumnNameAndExpressionByVariableToAssign(IReadOnlyDictionary<IUDDTType, IParameterizedCommand> columnParametizedByVariableToAssignValues)
        {
            var columnNameByVariableToAssign = new Dictionary<IUDDTType, string>();
            int index = 0;
            foreach (var pair in columnParametizedByVariableToAssignValues)
            {
                columnNameByVariableToAssign.Add(pair.Key, index.ToString());
                index++;
            }
            return columnNameByVariableToAssign;
        }

        static Dictionary<IUDDTType, string> ColumnNameByVariableToAssignFromColumnNameAndExpressionByVariableToAssign(IReadOnlyDictionary<IUDDTType, IEnumerable<string>> columnNameAndExpressionByVariableToAssign)
        {
            return columnNameAndExpressionByVariableToAssign.ToDictionary(p => p.Key, p => p.Value.ElementAt(0));
        }

    }
}
