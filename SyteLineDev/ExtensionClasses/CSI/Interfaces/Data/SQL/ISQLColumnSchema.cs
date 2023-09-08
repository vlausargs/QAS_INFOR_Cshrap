using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ISQLColumnSchema
    {
        Type ColumnType { get; }
    }
}
