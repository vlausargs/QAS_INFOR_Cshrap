using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowInt : ILowInt
    {
        IApplicationDB appDB;


        public LowInt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int? LowIntFn()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[LowInt]()";

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }
}
