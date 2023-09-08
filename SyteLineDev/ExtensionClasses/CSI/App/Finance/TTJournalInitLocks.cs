//PROJECT NAME: Finance
//CLASS NAME: TTJournalInitLocks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalInitLocks : ITTJournalInitLocks
	{
		readonly IApplicationDB appDB;
		
		
		public TTJournalInitLocks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) TTJournalInitLocksSp(int? OverrideLock = 0,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		int? CallFromBG = 0,
		decimal? UserId = 0,
		string CallFormCap = null)
		{
			ListYesNoType _OverrideLock = OverrideLock;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CallFromBG = CallFromBG;
			TokenType _UserId = UserId;
			FormNameOrCaptionType _CallFormCap = CallFormCap;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTJournalInitLocksSp";
				
				appDB.AddCommandParameter(cmd, "OverrideLock", _OverrideLock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CallFromBG", _CallFromBG, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFormCap", _CallFormCap, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
