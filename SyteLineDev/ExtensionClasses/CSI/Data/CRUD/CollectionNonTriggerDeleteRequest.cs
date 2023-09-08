using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionNonTriggerDeleteRequest : ICollectionNonTriggerDeleteRequest
    {
        public string TableName { get; }

        public IParameterizedCommand FromClause { get; }

        public IParameterizedCommand WhereClause { get; }

        public int MaximumRows { get; }

        CollectionNonTriggerDeleteRequest(
            string tableName,
            int? maximumRows,
            IParameterizedCommand fromClause,
            IParameterizedCommand whereClause)
        {
            this.TableName = tableName;
            this.MaximumRows = maximumRows ?? 0;
            this.FromClause = fromClause;
            this.WhereClause = whereClause;

            Contract.Requires<ArgumentNullException>(tableName != null, "TableName must be specified");
            Contract.Requires<ArgumentOutOfRangeException>(maximumRows >= 0, "maximumRows may not be less than zero");
        }

        public static ICollectionNonTriggerDeleteRequest SQLDelete(
            string tableName,
            int? maximumRows = 0,
            IParameterizedCommand fromClause = null,
            IParameterizedCommand whereClause = null)
        {
            return new CollectionNonTriggerDeleteRequest(tableName, maximumRows, fromClause, whereClause);
        }
    }
}
