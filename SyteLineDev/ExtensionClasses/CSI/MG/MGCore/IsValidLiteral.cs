using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class IsValidLiteral : IIsValidLiteral
	{
		IApplicationDB appDB;


		public IsValidLiteral(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

        public int? IsValidLiteralFn(string InputString)
        {
            VeryLongListType _InputString = InputString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[IsValidLiteral](@InputString)";

                appDB.AddCommandParameter(cmd, "InputString", _InputString, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<int?>(cmd);

                return Output;
            }
        }
    }
}
