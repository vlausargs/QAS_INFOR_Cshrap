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
    public class MGCommandProvider : ICommandProvider
    {
        readonly AppDB appDB;
        readonly IAppDBProvider appDBProvider;
        [Obsolete("Use other constructor. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
        public MGCommandProvider(AppDB appDB)
        {
            this.appDB = appDB;
        }

        public IDbCommand CreateCommand()
        {
            return RuntimeApp.CreateCommand();
        }

        public MGCommandProvider(IAppDBProvider appDBProvider)
        {
            this.appDBProvider = appDBProvider;
        }

        private AppDB RuntimeApp
        {
            get
            {
                if (appDB != null) return this.appDB;
                return appDBProvider.AppDB;
            }
        }
    }
}
