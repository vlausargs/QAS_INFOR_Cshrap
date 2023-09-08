using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ILiteralProvider
    {
        string FormatLiteral(object value);
    }
}
