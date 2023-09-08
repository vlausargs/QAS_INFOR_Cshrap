//PROJECT NAME: Finance
//CLASS NAME: AllowManualJournalEntry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class AllowManualJournalEntry : IAllowManualJournalEntry
	{
		readonly IApplicationDB appDB;
		
		
		public AllowManualJournalEntry(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AllowManualJournalEntrySp(string GroupName,
		decimal? UserId,
		string pAcctNumber,
		int? IsSecureCtlAcct,
		string Infobar)
		{
			GroupnameType _GroupName = GroupName;
			TokenType _UserId = UserId;
			AcctType _pAcctNumber = pAcctNumber;
			ListYesNoType _IsSecureCtlAcct = IsSecureCtlAcct;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AllowManualJournalEntrySp";
				
				appDB.AddCommandParameter(cmd, "GroupName", _GroupName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctNumber", _pAcctNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsSecureCtlAcct", _IsSecureCtlAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
