using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public interface ILoadRequestVariablesUpdate
    {
        void UpdateRequestVariables(ICollectionLoadResponse response, IReadOnlyDictionary<IUDDTType, string> columnNameByVariableToAssign);
    }
}
