//PROJECT NAME: Data
//CLASS NAME: UserCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UserCode : IUserCode
	{
		readonly IApplicationDB appDB;

		public UserCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string UserCodeFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UserCode]()";

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
