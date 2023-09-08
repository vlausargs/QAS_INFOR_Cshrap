using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    public class SQLTableSchemaCache : ITableSchemaCache
    {
        //temporary poor mans cache
        object cacheLocker = new object();
        static Dictionary<string, ISQLTableSchema> physicalTableCache = new Dictionary<string, ISQLTableSchema>();
        Dictionary<string, ISQLTableSchema> tempTableCache = new Dictionary<string, ISQLTableSchema>();

        public ISQLTableSchema Get(string tableName)
        {
            lock (cacheLocker)
            {
                ISQLTableSchema tableSchema;
                if (tableName.Substring(0, 1) == "#")
                    tempTableCache.TryGetValue(tableName, out tableSchema);
                else
                    physicalTableCache.TryGetValue(tableName, out tableSchema);

                return tableSchema;
            }
        }

        public void Put(string tableName, ISQLTableSchema tableSchema)
        {
            lock (cacheLocker)
            {
                if (tableName.Substring(0, 1) == "#")
                    tempTableCache[tableName] = tableSchema;
                else
                    physicalTableCache[tableName] = tableSchema;
            }
        }

        public void Clear()
        {
            lock (cacheLocker)
            {
                physicalTableCache = new Dictionary<string, ISQLTableSchema>();
                tempTableCache = new Dictionary<string, ISQLTableSchema>();
            }
        }
    }
}
