using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using Mongoose.IDO.DataAccess;

namespace KDU_Report
{
    public static class SQLFactory
    {
        public static IDbCommand createCommmand(ApplicationDB db, String query)
        {
            var cmd = db.CreateCommand();
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.Text;
            return cmd;
        }
    }
}
