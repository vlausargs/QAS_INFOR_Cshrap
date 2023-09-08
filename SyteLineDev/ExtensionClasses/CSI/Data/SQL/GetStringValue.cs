using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
	public class GetStringValue : IGetStringValue
	{
		IApplicationDB appDB;


		public GetStringValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string GetStringValueFn(string InputString)
		{
			StringType _InputString = InputString;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetStringValue](@InputString)";

				appDB.AddCommandParameter(cmd, "InputString", _InputString, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
