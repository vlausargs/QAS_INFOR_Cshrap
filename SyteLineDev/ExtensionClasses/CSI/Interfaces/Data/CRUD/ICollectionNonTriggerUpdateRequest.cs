using CSI.Data.SQL;
using System.Collections.Generic;

namespace CSI.Data.CRUD
{
    public interface ICollectionNonTriggerUpdateRequest
    {
        IParameterizedCommand FromClause { get; }
        string TableName { get; }
        IReadOnlyDictionary<string, IParameterizedCommand> ExpressionByColumnToAssign { get; }
        IParameterizedCommand WhereClause { get; }
        int MaximumRows { get; }
    }
}