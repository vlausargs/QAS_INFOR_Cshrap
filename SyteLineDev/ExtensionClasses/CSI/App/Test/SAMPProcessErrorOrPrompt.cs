//PROJECT NAME: CSITest
//CLASS NAME: SAMPProcessErrorOrPrompt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Test
{
	public interface ISAMPProcessErrorOrPrompt
	{
		int SAMPProcessErrorOrPromptSp(byte? WarnOnDuplicate,
		                               ref string PromptMsg,
		                               ref string PromptButtons,
		                               ref string Infobar);
	}
	
	public class SAMPProcessErrorOrPrompt : ISAMPProcessErrorOrPrompt
	{
		readonly IApplicationDB appDB;
		
		public SAMPProcessErrorOrPrompt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SAMPProcessErrorOrPromptSp(byte? WarnOnDuplicate,
		                                      ref string PromptMsg,
		                                      ref string PromptButtons,
		                                      ref string Infobar)
		{
			Flag _WarnOnDuplicate = WarnOnDuplicate;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SAMPProcessErrorOrPromptSp";
				
				appDB.AddCommandParameter(cmd, "WarnOnDuplicate", _WarnOnDuplicate, ParameterDirection.Input);
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
