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
    public class StringOf : IStringOf
    {
        IApplicationDB appDB;


        public StringOf(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string StringOfFn(string Parm)
        {
            Infobar _Parm = Parm;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[StringOf](@Parm)";

                appDB.AddCommandParameter(cmd, "Parm", _Parm, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
