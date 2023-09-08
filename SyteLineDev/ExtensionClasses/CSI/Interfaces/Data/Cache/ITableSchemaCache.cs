using System;
using System.Collections.Generic;
using System.Text;
using CSI.MG;
using CSI.Data.Cache;
using CSI.Data.SQL;

namespace CSI.Data.Cache
{
    public interface ITableSchemaCache
    {
        ISQLTableSchema Get(string tableName);
        void Put(string tableName, ISQLTableSchema tableSchema);
    }
}
