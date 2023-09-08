using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IMathUtil
    {
        T Ceiling<T>(object input);
        T Floor<T>(object input);
        T Abs<T>(object input);
        T Exp<T>(object input);
        T Sqrt<T>(object input);
        T Pow<T>(object input, object input2);
        T Round<T>(object input, object input2, object input3 = null);
    }
}
