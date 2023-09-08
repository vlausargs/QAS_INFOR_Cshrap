//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateTargetPoNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IValidateTargetPoNumForCopy
	{
		int ValidateTargetPoNumForCopySp(ref string PoType,
		                                 ref string PoNum,
		                                 string FromPoType,
		                                 string FromPoNum,
		                                 ref short? StartLineNum,
		                                 ref short? EndLineNum,
		                                 ref string Prompt,
		                                 ref string PromptButtons,
		                                 ref string Infobar);
	}
	
	public class ValidateTargetPoNumForCopy : IValidateTargetPoNumForCopy
	{
		readonly IApplicationDB appDB;
		
		public ValidateTargetPoNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateTargetPoNumForCopySp(ref string PoType,
		                                        ref string PoNum,
		                                        string FromPoType,
		                                        string FromPoNum,
		                                        ref short? StartLineNum,
		                                        ref short? EndLineNum,
		                                        ref string Prompt,
		                                        ref string PromptButtons,
		                                        ref string Infobar)
		{
			PoTypeType _PoType = PoType;
			PoNumType _PoNum = PoNum;
			PoTypeType _FromPoType = FromPoType;
			PoNumType _FromPoNum = FromPoNum;
			PoLineType _StartLineNum = StartLineNum;
			PoLineType _EndLineNum = EndLineNum;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateTargetPoNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "PoType", _PoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromPoType", _FromPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPoNum", _FromPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoType = _PoType;
				PoNum = _PoNum;
				StartLineNum = _StartLineNum;
				EndLineNum = _EndLineNum;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
