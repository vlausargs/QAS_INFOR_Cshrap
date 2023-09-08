using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.MG
{
    public interface IAddCommandParameterWithValue
    {
        IDbDataParameter AddCommandParameterWithValue(IDbCommand cmd, string name, object value, ParameterDirection direction = ParameterDirection.Input);
    }
}