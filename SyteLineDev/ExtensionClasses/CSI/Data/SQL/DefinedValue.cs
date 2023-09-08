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
	public class DefinedValue : IDefinedValue
	{
		IApplicationDB appDB;


		public DefinedValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string DefinedValueFn(string VariableName)
		{
			StringType _VariableName = VariableName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DefinedValue](@VariableName)";

				appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
