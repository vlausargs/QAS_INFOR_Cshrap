using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IMGInvokeParameter
    {
        string Value { get; set; }
        T GetValue<T>();
        T? GetNullableValue<T>() where T : struct;
    }
}
