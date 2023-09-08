using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG.MGCore;
using CSI.MG;

namespace CSI.Data.SQL
{
    public class LowDate : ILowDate
    {
        IApplicationDB appDB;


        public LowDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public DateTime? LowDateFn()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[LowDate]()";

                var Output = appDB.ExecuteScalar<DateTime?>(cmd);

                return Output;
            }
        }
    }
}
