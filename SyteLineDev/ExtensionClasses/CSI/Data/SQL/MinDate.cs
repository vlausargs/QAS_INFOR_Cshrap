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
	public class MinDate : IMinDate
	{
		IApplicationDB appDB;


		public MinDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public DateTime? MinDateFn(DateTime? Date1,
		DateTime? Date2)
		{
			DateType _Date1 = Date1;
			DateType _Date2 = Date2;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MinDate](@Date1, @Date2)";

				appDB.AddCommandParameter(cmd, "Date1", _Date1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date2", _Date2, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<DateTime?>(cmd);

				return Output;
			}
		}
	}
}
