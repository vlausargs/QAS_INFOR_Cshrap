using CSI.Data.SQL;
using System;
using System.Collections.Generic;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerInsertRequest : ICollectionNonTriggerInsertRequest
    {
        public string TargetTableName { get; }

        public IReadOnlyDictionary<string, IParameterizedCommand> ValuesByExpressionToAssign { get; }

        public IParameterizedCommand FromClause { get; }

        public IParameterizedCommand WhereClause { get; }

        public IParameterizedCommand OrderByClause { get; }

        public int MaximumRows { get; }

        public List<string> TargetColumns { get; }

        public bool Distinct { get; }

        CollectionNonTriggerInsertRequest(
            string targetTableName,
            List<string> targetColumns,
            int? maximumRows,
            IReadOnlyDictionary<string, IParameterizedCommand> valuesByExpressionToAssign,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            bool distinct)
        {
            this.TargetTableName = targetTableName;
            this.TargetColumns = targetColumns;
            this.MaximumRows = maximumRows ?? 0;
            this.ValuesByExpressionToAssign = valuesByExpressionToAssign;
            this.FromClause = fromClause;
            this.WhereClause = whereClause;
            this.OrderByClause = orderByClause;
            this.Distinct = distinct;

            Contract.Requires<ArgumentNullException>(targetTableName != null, "targetTableName must be specified");
            Contract.Requires<ArgumentNullException>(targetColumns != null, "targetColumns must be specified");
            Contract.Requires<ArgumentNullException>(valuesByExpressionToAssign != null, "valuesByExpressionToAssign must be specified");
            Contract.Requires<ArgumentOutOfRangeException>(maximumRows >= 0, "maximumRows may not be less than zero");
        }

        public static ICollectionNonTriggerInsertRequest SQLInsert(
            string targetTableName,
            List<string> targetColumns,
            IReadOnlyDictionary<string, IParameterizedCommand> valuesByExpressionToAssign,
            int? maximumRows,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause,
            IParameterizedCommand orderByClause,
            bool distinct)
        {
            return new CollectionNonTriggerInsertRequest(targetTableName, targetColumns, maximumRows, valuesByExpressionToAssign, fromClause, whereClause, orderByClause, distinct);
        }
    }
}
