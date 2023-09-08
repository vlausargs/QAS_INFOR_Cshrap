using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    public interface ITablePrimaryKeyCache
    {
        IEnumerable<string> Get(string tableName);
        void Put(string tableName, IEnumerable<string> primaryKey);
        void Clear();
    }
}
