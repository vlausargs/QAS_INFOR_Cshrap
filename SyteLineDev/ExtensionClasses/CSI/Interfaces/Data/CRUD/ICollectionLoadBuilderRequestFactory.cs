using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ICollectionLoadBuilderRequestFactory
    {
        ICollectionLoadBuilderRequest Create(IReadOnlyDictionary<string, object> columnExpressionByColumnName);
        ICollectionLoadBuilderRequest Create(IReadOnlyDictionary<IUDDTType, string> columnExpressionByVariableToAssign);
        ICollectionLoadBuilderRequest Create(IReadOnlyDictionary<string, IParameterizedCommand> columnParametizedByColumnName);
        IParameterizedCommand Clause(string clauseTemplate, params object[] clauseParameters);
    }
}
