//PROJECT NAME: Data
//CLASS NAME: App_LoadESBSecurityUserMaster.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_LoadESBSecurityUserMaster : IApp_LoadESBSecurityUserMaster
	{
		readonly IApplicationDB appDB;
		
		public App_LoadESBSecurityUserMaster(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) App_LoadESBSecurityUserMasterSp(
			string WorkstationLogin,
			string Action,
			string Status,
			string GivenName,
			string FamilyName,
			string UserName,
			string EmailAddress,
			int? IsNewUserNameRow,
			decimal? OldUserId,
			string InfoBar)
		{
			MediumDescType _WorkstationLogin = WorkstationLogin;
			StringType _Action = Action;
			StringType _Status = Status;
			LongDescType _GivenName = GivenName;
			LongDescType _FamilyName = FamilyName;
			UsernameType _UserName = UserName;
			EmailType _EmailAddress = EmailAddress;
			ListYesNoType _IsNewUserNameRow = IsNewUserNameRow;
			TokenType _OldUserId = OldUserId;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_LoadESBSecurityUserMasterSp";
				
				appDB.AddCommandParameter(cmd, "WorkstationLogin", _WorkstationLogin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GivenName", _GivenName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FamilyName", _FamilyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailAddress", _EmailAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsNewUserNameRow", _IsNewUserNameRow, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUserId", _OldUserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
