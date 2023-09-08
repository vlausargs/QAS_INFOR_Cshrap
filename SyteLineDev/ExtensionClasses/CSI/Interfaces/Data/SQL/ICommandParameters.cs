using CSI.Data.SQL.UDDT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ICommandParameters
    {
        IDbDataParameter AddCommandParameterWithValue(IDbCommand cmd, string name, IUDDTType value, ParameterDirection direction = ParameterDirection.Input);
        dynamic GetParameterValue(IDbDataParameter parm);
        void GetOutputParameters(IDbCommand cmd);
        void ClearOutputParameters();
    }
}
