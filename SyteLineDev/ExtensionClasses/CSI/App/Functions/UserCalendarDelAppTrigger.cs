//PROJECT NAME: Data
//CLASS NAME: UserCalendarDelAppTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UserCalendarDelAppTrigger : IUserCalendarDelAppTrigger
	{
		readonly IApplicationDB appDB;
		
		public UserCalendarDelAppTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UserCalendarDelAppTriggerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UserCalendarDelAppTriggerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
