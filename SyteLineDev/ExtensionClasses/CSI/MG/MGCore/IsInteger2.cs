using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class IsInteger2 : IIsInteger2
	{
		IApplicationDB appDB;


		public IsInteger2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? IsInteger2Fn(string Value)
		{
			LongListType _Value = Value;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsInteger2](@Value)";

				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
