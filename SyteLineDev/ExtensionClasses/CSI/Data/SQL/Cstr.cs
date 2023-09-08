using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
	public class Cstr : ICstr
	{
		IApplicationDB appDB;


		public Cstr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string CstrFn(object Value)
		{
			StringType _Value = Convert.ToString(Value);

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Cstr](@Value)";

				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
