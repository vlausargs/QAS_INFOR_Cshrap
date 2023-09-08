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
	public class HighDate : IHighDate
	{
		IApplicationDB appDB;


		public HighDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public DateTime? HighDateFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[HighDate]()";

				var Output = appDB.ExecuteScalar<DateTime?>(cmd);

				return Output;
			}
		}
	}
}
