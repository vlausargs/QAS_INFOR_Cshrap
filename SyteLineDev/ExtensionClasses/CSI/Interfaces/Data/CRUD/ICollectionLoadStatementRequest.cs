using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadStatementRequest
    {
        IParameterizedCommand SelectStatement { get; }

        IEnumerable<string> RequestedColumns { get; }

        IReadOnlyDictionary<string, string> ColumnExpressionByColumnName { get; }

        IReadOnlyDictionary<IUDDTType, string> ColumnNameByVariableToAssign { get; }

        /// <summary>
        /// The column name associated with each column and have parameterized value.
        /// </summary>
        IReadOnlyDictionary<string, IParameterizedCommand> ColumnParametizedByColumnName { get; }

        IReadOnlyDictionary<IUDDTType, IParameterizedCommand> ColumnParametizedByVariableToAssign { get; }


        /// <summary>
        /// The name of the SQL table to be updated or deleted, if available
        /// </summary>
        string TargetTableName { get; }
    }
}
