using CSI.Data.SQL;
using Mongoose.IDO.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGCommandExecutor : ICommandExecutor
    {
        readonly AppDB appDB;
        readonly ICommandParameters commandParameters;
        readonly IAppDBProvider appDBProvider;
        public MGCommandExecutor(IAppDBProvider appDBProvider, ICommandParameters commandParameters)
        {
            this.appDBProvider = appDBProvider;
            this.commandParameters = commandParameters;
        }
        [Obsolete("Use the other constuctor. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
        public MGCommandExecutor(AppDB appDB, ICommandParameters commandParameters)
        {
            this.appDB = appDB;
            this.commandParameters = commandParameters;
        }
        
        private AppDB RuntimeAppDB
        {
            get
            {
                if (this.appDB != null) return this.appDB;
                return this.appDBProvider.AppDB;
            }
        }

        public void ExecuteNonQuery(IDbCommand cmd)
        {
            cmd.CommandText = ReplaceCharZero(cmd.CommandText);
            RuntimeAppDB.ExecuteNonQuery(cmd);
            commandParameters.GetOutputParameters(cmd);
        }

        public IDataReader ExecuteReader(IDbCommand cmd)
        {
            cmd.CommandText = ReplaceCharZero(cmd.CommandText);
            var reader = RuntimeAppDB.ExecuteReader(cmd);
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
                retValue = RuntimeAppDB.ExecuteScalar(cmd);
                return (retValue != DBNull.Value) ? (T)Convert.ChangeType(retValue, type) : default(T);
            }
            else
            {
                retValue = RuntimeAppDB.ExecuteScalar(cmd);
                return (retValue != DBNull.Value) ? (T)Convert.ChangeType(retValue, typeof(T)) : default(T);
            }
        }

        private string ReplaceCharZero(string pendingExecuteSQL)
        {
            return pendingExecuteSQL.Replace("N'\0'", "NCHAR(0)").Replace("'\0'", "NCHAR(0)").Replace("\0", "NCHAR(0)");
        }
    }
}
