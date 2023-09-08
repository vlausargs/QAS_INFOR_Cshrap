using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    public class SQLTablePrimaryKeyCache : ITablePrimaryKeyCache
    {
        //temporary poor mans cache
        object cacheLocker = new object();
        static Dictionary<string, IEnumerable<string>> physicalTableCache = new Dictionary<string, IEnumerable<string>>();
        Dictionary<string, IEnumerable<string>> tempTableCache = new Dictionary<string, IEnumerable<string>>();

        public IEnumerable<string> Get(string tableName)
        {
            lock (cacheLocker)
            {
                IEnumerable<string> keys;
                if (tableName.Substring(0, 1) == "#")
                    tempTableCache.TryGetValue(tableName, out keys);
                else
                    physicalTableCache.TryGetValue(tableName, out keys);
                
                return keys;
            }
        }

        public void Put(string tableName, IEnumerable<string> primaryKey)
        {
            lock (cacheLocker)
            {
                if (tableName.Substring(0, 1) == "#")
                    tempTableCache[tableName] = primaryKey;
                else
                    physicalTableCache[tableName] = primaryKey;
            }
        }

        public void Clear()
        {
            lock (cacheLocker)
            {
                physicalTableCache = new Dictionary<string, IEnumerable<string>>();
                tempTableCache = new Dictionary<string, IEnumerable<string>>();
            }
        }
    }
}
