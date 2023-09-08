//PROJECT NAME: CSITest
//CLASS NAME: SAMPErrorOrPromptValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Test
{
	public interface ISAMPErrorOrPromptValidation
	{
		int SAMPErrorOrPromptValidationSp(int? CodeNum,
		                                  string Desc,
		                                  byte? WarnOnDuplicate,
		                                  ref byte? DuplicateExists,
		                                  ref string PromptMsg,
		                                  ref string PromptButtons,
		                                  ref string Infobar);
	}
	
	public class SAMPErrorOrPromptValidation : ISAMPErrorOrPromptValidation
	{
		readonly IApplicationDB appDB;
		
		public SAMPErrorOrPromptValidation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SAMPErrorOrPromptValidationSp(int? CodeNum,
		                                         string Desc,
		                                         byte? WarnOnDuplicate,
		                                         ref byte? DuplicateExists,
		                                         ref string PromptMsg,
		                                         ref string PromptButtons,
		                                         ref string Infobar)
		{
			IntType _CodeNum = CodeNum;
			StringType _Desc = Desc;
			Flag _WarnOnDuplicate = WarnOnDuplicate;
			Flag _DuplicateExists = DuplicateExists;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SAMPErrorOrPromptValidationSp";
				
				appDB.AddCommandParameter(cmd, "CodeNum", _CodeNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Desc", _Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarnOnDuplicate", _WarnOnDuplicate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DuplicateExists", _DuplicateExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DuplicateExists = _DuplicateExists;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
