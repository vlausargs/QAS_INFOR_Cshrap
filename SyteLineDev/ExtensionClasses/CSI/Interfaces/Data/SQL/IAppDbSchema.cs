using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface IAppDbSchema
    {
        IEnumerable<string> GetPrimaryKeyColumns(string tableName);

        ISQLTableSchema GetTableSchema(string tableName);
    }
}
