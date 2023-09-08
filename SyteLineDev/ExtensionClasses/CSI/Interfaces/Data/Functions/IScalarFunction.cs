using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Functions
{
    public interface IScalarFunction
    {
        T Execute<T>(string function, params object[] functionParameters);
    }
}
