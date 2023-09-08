using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public interface IParameterProvider
    {
        IDataParameter CreateParameter(string parameterName, object value);
    }
}
