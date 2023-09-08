//PROJECT NAME: Data
//CLASS NAME: IAndSqlWhereWithISNULL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IAndSqlWhereWithISNULL
    {
        string AndSqlWhereWithISNULLFn(
            string TableAlias,
            string ColumnName,
            string NullValue,
            int? UseQuotes,
            string LowValue,
            string HighValue);
    }
}

