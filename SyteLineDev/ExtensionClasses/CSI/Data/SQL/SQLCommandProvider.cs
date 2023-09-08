using CSI.Data.SQL;
using System.Data;
using System.Data.SqlClient;

namespace CSI.Data.SQL
{
    public class SQLCommandProvider : ICommandProvider
    {
        readonly IDbConnection connection;
        readonly IDbTransaction transaction;
        readonly int sqlTimeout;

        public SQLCommandProvider(IDbConnection connection, IDbTransaction transaction, int sqlTimeout)
        {
            this.connection = connection;
            this.transaction = transaction;
            this.sqlTimeout = sqlTimeout;
        }

        public IDbCommand CreateCommand()
        {
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            cmd.CommandTimeout = sqlTimeout;

            return cmd;
        }
    }
}