using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CSI.Data.SQL
{
    public class SQLBulkCopy : ISQLBulkCopy
    {
        SqlBulkCopy bulkCopy;
        SqlTransaction sqlTransaction = null;
        
        public SQLBulkCopy(SqlTransaction transaction, ICommandProvider commandProvider)
        {
            if (commandProvider == null)
                throw new ArgumentNullException(nameof(commandProvider));
            IDbCommand iDbCommand = commandProvider.CreateCommand();

            transaction = transaction ?? (SqlTransaction) iDbCommand.Transaction;
            if (transaction == null)
            {
                transaction = ((SqlConnection)iDbCommand.Connection).BeginTransaction();
                this.sqlTransaction = transaction;
            }

            this.bulkCopy = new SqlBulkCopy((SqlConnection)iDbCommand.Connection, SqlBulkCopyOptions.Default, transaction);
        }

        public void Dispose()
        {
            if (this.sqlTransaction != null)
            {
                this.sqlTransaction.Commit();
            }
            ((IDisposable)bulkCopy).Dispose();
        }

        public string DestinationTableName { get => bulkCopy.DestinationTableName; set { bulkCopy.DestinationTableName = value; } }
        public int BulkCopyTimeout { get => bulkCopy.BulkCopyTimeout; set { bulkCopy.BulkCopyTimeout = value; } }

        public void WriteToServer(DataTable data)
        {
            bulkCopy.WriteToServer(data);
            
        }

        public void SetColumnMapping(IEnumerable<string> columns)
        {
            foreach (var col in columns)
            {
                this.bulkCopy.ColumnMappings.Add(col,col);
            }
        }

        public List<string> GetColumnMapping()
        {
            var columns = new List<string>();

            foreach (SqlBulkCopyColumnMapping cols in this.bulkCopy.ColumnMappings)
            {
                columns.Add(cols.SourceColumn);
            }
            return columns;
        }
    }
}
