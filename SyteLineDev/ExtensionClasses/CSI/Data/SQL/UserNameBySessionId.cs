using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
	public class UserNameBySessionId : IUserNameBySessionId
	{
		IApplicationDB appDB;


		public UserNameBySessionId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string UserNameBySessionIdFn(Guid? SessionID)
		{
			RowPointerType _SessionID = SessionID;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UserNameBySessionId](@SessionID)";

				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
