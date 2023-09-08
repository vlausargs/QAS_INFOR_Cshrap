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
	public class UserName2 : IUserName2
	{
		IApplicationDB appDB;


		public UserName2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string UserName2Sp()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UserName2Sp]()";

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
