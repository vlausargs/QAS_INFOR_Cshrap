//PROJECT NAME: CSIVendor
//CLASS NAME: TTGlBankCommit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ITTGlBankCommit
	{
		int TTGlBankCommitSp(ref string PromptMsg,
		                     ref string PromptButtons,
		                     ref string Infobar);
	}
	
	public class TTGlBankCommit : ITTGlBankCommit
	{
		readonly IApplicationDB appDB;
		
		public TTGlBankCommit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int TTGlBankCommitSp(ref string PromptMsg,
		                            ref string PromptButtons,
		                            ref string Infobar)
		{
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTGlBankCommitSp";
				
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
