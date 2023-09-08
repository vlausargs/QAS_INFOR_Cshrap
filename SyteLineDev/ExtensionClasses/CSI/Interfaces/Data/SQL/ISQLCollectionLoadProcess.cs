using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ISQLCollectionLoadProcess
    {
        ICollectionLoadResponse Process(IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign, string statement, IEnumerable<IDataParameter> parameters, int? maximumRows, IEnumerable<string> augmentedRequestedColumns);
    }
}
