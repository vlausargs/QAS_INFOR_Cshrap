using CSI.Data.SQL;

namespace CSI.Data.CRUD
{
    public interface ICollectionNonTriggerDeleteRequest
    {

        IParameterizedCommand FromClause { get; }
        string TableName { get; }
        IParameterizedCommand WhereClause { get; }
        int MaximumRows { get; }
    }
}