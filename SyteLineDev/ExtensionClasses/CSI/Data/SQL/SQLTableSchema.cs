using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLTableSchema : ISQLTableSchema
    {
        readonly Dictionary<string, ISQLColumnSchema> columns = new Dictionary<string, ISQLColumnSchema>();

        public IReadOnlyDictionary<string, ISQLColumnSchema> ColumnInfo => columns;

        public void AddColumn(string columnName, ISQLColumnSchema columnSchema)
        {
            columns.Add(columnName, columnSchema);
        }
    }
}
