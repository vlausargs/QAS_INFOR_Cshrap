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
	public class DoubleQuote : IDoubleQuote
	{
		IApplicationDB appDB;


		public DoubleQuote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string DoubleQuoteFn(string Value)
		{
			LongListType _Value = Value;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DoubleQuote](@Value)";

				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
