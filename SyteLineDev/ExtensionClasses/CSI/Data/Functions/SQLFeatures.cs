using CSI.Data.Cache;
using CSI.Data.SQL;
using CSI.MG;
using CSI.MG.MGCore;
using System.Data;
using CSI.Interfaces.Data;

namespace CSI.Data.Functions
{
    public class SQLFeatures : ISQLDependencies
    {
        IDbConnection connection;
        IDbTransaction transaction;
        int sqlTimeout;
        int recordCap;

        public SQLFeatures(IDbConnection connection, IDbTransaction transaction, int sqlTimeout, int recordCap)
        {
            this.connection = connection;
            this.transaction = transaction;
            this.sqlTimeout = sqlTimeout;
            this.recordCap = recordCap;
        }

        public ISQLBunchingContext SQLBunchingContext => new SQLBunchingContext(false, "", recordCap, LoadType.First);
        public IMessageProvider SQLMessageProvider => new SQLMessageProvider(connection, transaction);
        public ICommandProvider SQLCommandProvider => new SQLCommandProvider(connection, transaction, sqlTimeout);
        public ISetSite SetSite => new SQLSetSite(connection, transaction);
        public IUserPrincipal UserPrincipal => new SQLUserPrincipal(SQLCommandProvider);

        public IFileServer FileServer => new SQLFileServer();
        public IApplicationEvent ApplicationEvent => new SQLApplicationEvent();
        public IEmail Email => new SQLEmail();
    }
}