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
	public class SessionID : ISessionID
	{
		IApplicationDB appDB;


		public SessionID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public Guid SessionIDSp()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SessionIDSp]()";

				var Output = appDB.ExecuteScalar<Guid>(cmd);

				return Output;
			}
		}
	}
}
