using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ISQLCollectionLoadBuilderProcess
    {
        ICollectionLoadResponse Process(
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            IEnumerable<string> columns,
            IReadOnlyDictionary<string, object> data);
        ICollectionLoadResponse Process(
            IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign,
            IEnumerable<string> columns,
            IReadOnlyDictionary<string, IParameterizedCommand> data);
    }
}
