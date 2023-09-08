using CSI.MG;
using CSI.MG.MGCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.SQL
{
	public class AllSitesSameDb : IAllSitesSameDb
	{
		IApplicationDB appDB;


		public AllSitesSameDb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? AllSitesSameDbFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[AllSitesSameDb]()";

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
