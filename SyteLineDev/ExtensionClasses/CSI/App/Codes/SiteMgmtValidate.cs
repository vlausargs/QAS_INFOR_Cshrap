//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class SiteMgmtValidate : ISiteMgmtValidate
	{
		readonly IApplicationDB appDB;
		
		
		public SiteMgmtValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string PUsername,
		string PQueueSite) SiteMgmtValidateSp(string PSite,
		string PNotificationEmailAddress,
		string SiteManagementAction,
		string Infobar,
		string PUsername,
		string PQueueSite)
		{
			SiteType _PSite = PSite;
			EmailType _PNotificationEmailAddress = PNotificationEmailAddress;
			SiteManagementActionType _SiteManagementAction = SiteManagementAction;
			InfobarType _Infobar = Infobar;
			UsernameType _PUsername = PUsername;
			SiteType _PQueueSite = PQueueSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SiteMgmtValidateSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNotificationEmailAddress", _PNotificationEmailAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteManagementAction", _SiteManagementAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUsername", _PUsername, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQueueSite", _PQueueSite, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PUsername = _PUsername;
				PQueueSite = _PQueueSite;
				
				return (Severity, Infobar, PUsername, PQueueSite);
			}
		}
	}
}
