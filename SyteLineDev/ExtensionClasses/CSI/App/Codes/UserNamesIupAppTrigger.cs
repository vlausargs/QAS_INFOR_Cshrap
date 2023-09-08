//PROJECT NAME: Codes
//CLASS NAME: UserNamesIupAppTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UserNamesIupAppTrigger : IUserNamesIupAppTrigger
	{
		readonly IApplicationDB appDB;
		
		public UserNamesIupAppTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UserNamesIupAppTriggerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UserNamesIupAppTriggerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
