using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerUpdateRequest : ICollectionNonTriggerUpdateRequest
    {
        public string TableName { get; }

        public IReadOnlyDictionary<string, IParameterizedCommand> ExpressionByColumnToAssign { get; }

        public IParameterizedCommand FromClause { get; }

        public IParameterizedCommand WhereClause { get; }

        public int MaximumRows { get; }

        CollectionNonTriggerUpdateRequest(
            string tableName,
            int? maximumRows,
            IReadOnlyDictionary<string, IParameterizedCommand> expressionByColumnToAssign,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause)
        {
            this.TableName = tableName;
            this.MaximumRows = maximumRows ?? 0;
            this.ExpressionByColumnToAssign = expressionByColumnToAssign;
            this.FromClause = fromClause;
            this.WhereClause = whereClause;

            Contract.Requires<ArgumentNullException>(tableName != null, "TableName must be specified");
            Contract.Requires<ArgumentNullException>(expressionByColumnToAssign != null, "expressionByColumnToAssign must be specified");
            Contract.Requires<ArgumentOutOfRangeException>(maximumRows >= 0, "maximumRows may not be less than zero");
        }

        public static ICollectionNonTriggerUpdateRequest SQLUpdate(
            string tableName,
            IReadOnlyDictionary<string, IParameterizedCommand> expressionByColumnToAssign = null,
            int? maximumRows = 0,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null)
        {
            return new CollectionNonTriggerUpdateRequest(tableName, maximumRows, expressionByColumnToAssign, fromClause, whereClause);
        }
    }
}
