using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ISQLBulkCopy : IDisposable
    {
        string DestinationTableName { get; set; }
        int BulkCopyTimeout { get; set; }
        void WriteToServer(DataTable dtProcess);
        void SetColumnMapping(IEnumerable<string> columns);
        List<string> GetColumnMapping();
    }
}
