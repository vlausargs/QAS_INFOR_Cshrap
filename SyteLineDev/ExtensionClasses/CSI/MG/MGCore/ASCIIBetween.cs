using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class ASCIIBetween : IASCIIBetween
	{
		IApplicationDB appDB;


		public ASCIIBetween(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

        public bool? ASCIIBetweenFn(string Expr,
        string Starting,
        string Ending)
        {
            StringType _Expr = Expr;
            StringType _Starting = Starting;
            StringType _Ending = Ending;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ASCIIBetween](@Expr, @Starting, @Ending)";

                appDB.AddCommandParameter(cmd, "Expr", _Expr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Starting", _Starting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Ending", _Ending, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<bool?>(cmd);

                return Output;
            }
        }
    }
}
