using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ISQLTableSchema
    {
        IReadOnlyDictionary<string, ISQLColumnSchema> ColumnInfo { get; }
        void AddColumn(string columnName, ISQLColumnSchema columnSchema);
    }
}
