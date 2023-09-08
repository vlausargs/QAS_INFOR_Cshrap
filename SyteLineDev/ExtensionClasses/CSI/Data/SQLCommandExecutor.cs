using CSI.Data.SQL;
using System;
using System.Data;

namespace CSI.Data
{
    public class SQLCommandExecutor : ICommandExecutor
    {

        ICommandParameters commandParameters;
        public SQLCommandExecutor(ICommandParameters commandParameters)
        {
            this.commandParameters = commandParameters;
        }

        public void ExecuteNonQuery(IDbCommand cmd)
        {
            cmd.CommandText = ReplaceCharZero(cmd.CommandText);
            cmd.ExecuteNonQuery();
            commandParameters.GetOutputParameters(cmd);
        }

        public IDataReader ExecuteReader(IDbCommand cmd)
        {
            cmd.CommandText = ReplaceCharZero(cmd.CommandText);
            var reader = cmd.ExecuteReader();
            return reader;
        }

        public T ExecuteScalar<T>(IDbCommand cmd)
        {
            var type = typeof(T);
            object retValue = null;
            cmd.CommandText = ReplaceCharZero(cmd.CommandText);
            if (Nullable.GetUnderlyingType(type) != null)
            {
                type = Nullable.GetUnderlyingType(type);
                retValue = cmd.ExecuteScalar();
                return (retValue != DBNull.Value) ? (T)Convert.ChangeType(retValue, type) : default(T);
            }
            else
            {
                retValue = cmd.ExecuteScalar();
                return (retValue != DBNull.Value) ? (T)Convert.ChangeType(retValue, typeof(T)) : default(T);
            }
        }

        private string ReplaceCharZero(string pendingExecuteSQL)
        {
            return pendingExecuteSQL.Replace("N'\0'", "NCHAR(0)").Replace("'\0'", "NCHAR(0)").Replace("\0", "NCHAR(0)");
        }
    }
}