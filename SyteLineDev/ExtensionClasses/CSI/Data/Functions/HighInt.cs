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
	public class HighInt : IHighInt
	{
		IApplicationDB appDB;


		public HighInt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? HighIntFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[HighInt]()";

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
