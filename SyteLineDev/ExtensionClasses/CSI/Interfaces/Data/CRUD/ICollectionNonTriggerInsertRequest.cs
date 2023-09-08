using CSI.Data.SQL;
using System.Collections.Generic;

namespace CSI.Data.CRUD
{
    public interface ICollectionNonTriggerInsertRequest
    {
        int MaximumRows { get; }
        string TargetTableName { get; }
        List<string> TargetColumns { get; }
        IReadOnlyDictionary<string, IParameterizedCommand> ValuesByExpressionToAssign { get; }
        IParameterizedCommand FromClause { get; }
        IParameterizedCommand WhereClause { get; }
        IParameterizedCommand OrderByClause { get; }

        bool Distinct { get; }
    }
}