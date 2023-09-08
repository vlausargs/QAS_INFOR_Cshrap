//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtNotify.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class SiteMgmtNotify : ISiteMgmtNotify
	{
		readonly IApplicationDB appDB;
		
		
		public SiteMgmtNotify(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SiteMgmtNotifySp(string PSite,
		int? PSuccess,
		string PErrorMsg,
		string PUsername,
		string PNotificationEmailAddress,
		string PQueueSite)
		{
			SiteType _PSite = PSite;
			ListYesNoType _PSuccess = PSuccess;
			LongListType _PErrorMsg = PErrorMsg;
			UsernameType _PUsername = PUsername;
			EmailType _PNotificationEmailAddress = PNotificationEmailAddress;
			SiteType _PQueueSite = PQueueSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SiteMgmtNotifySp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuccess", _PSuccess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PErrorMsg", _PErrorMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUsername", _PUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNotificationEmailAddress", _PNotificationEmailAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQueueSite", _PQueueSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
