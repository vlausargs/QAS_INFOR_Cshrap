using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IVariableUtil
    {
        object GetValue<T>(object input, bool withoutQuotes = false);
        object GetValue(object input, bool withoutQuotes = false);
        string GetQuotedValue<T>(T input);
    }
}
