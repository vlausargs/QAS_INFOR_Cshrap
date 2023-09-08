using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadBuilderRequest
    {
        IReadOnlyDictionary<string, object> ColumnExpressionByColumnName { get; }
        IReadOnlyDictionary<IUDDTType, string> ColumnNameByVariableToAssign { get; }
        IReadOnlyDictionary<string, IParameterizedCommand> ColumnParametizedByColumnName { get; }
        IEnumerable<string> RequestedColumns { get; }
    }
}
