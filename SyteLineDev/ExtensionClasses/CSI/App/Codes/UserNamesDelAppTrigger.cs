//PROJECT NAME: Codes
//CLASS NAME: UserNamesDelAppTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UserNamesDelAppTrigger : IUserNamesDelAppTrigger
	{
		readonly IApplicationDB appDB;
		
		public UserNamesDelAppTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UserNamesDelAppTriggerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UserNamesDelAppTriggerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
