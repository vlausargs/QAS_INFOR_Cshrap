//PROJECT NAME: Finance
//CLASS NAME: JournalEntriesValidateId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalEntriesValidateId : IJournalEntriesValidateId
	{
		readonly IApplicationDB appDB;
		
		
		public JournalEntriesValidateId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) JournalEntriesValidateIdSp(string PId,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string Callfrom = null,
		string GLVouchers = null)
		{
			JournalIdType _PId = PId;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			StringType _Callfrom = Callfrom;
			InvNumVoucherType _GLVouchers = GLVouchers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalEntriesValidateIdSp";
				
				appDB.AddCommandParameter(cmd, "PId", _PId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Callfrom", _Callfrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GLVouchers", _GLVouchers, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
