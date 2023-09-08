//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateTargetCoNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IValidateTargetCoNumForCopy
	{
		int ValidateTargetCoNumForCopySp(string OrderType,
		                                 ref string CoNum,
		                                 string FROMOrderType,
		                                 string FROMCoNum,
		                                 ref short? StartLineNum,
		                                 ref short? EndLineNum,
		                                 ref string Prompt,
		                                 ref string PromptButtons,
		                                 ref string Infobar);
	}
	
	public class ValidateTargetCoNumForCopy : IValidateTargetCoNumForCopy
	{
		readonly IApplicationDB appDB;
		
		public ValidateTargetCoNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateTargetCoNumForCopySp(string OrderType,
		                                        ref string CoNum,
		                                        string FROMOrderType,
		                                        string FROMCoNum,
		                                        ref short? StartLineNum,
		                                        ref short? EndLineNum,
		                                        ref string Prompt,
		                                        ref string PromptButtons,
		                                        ref string Infobar)
		{
			CoTypeType _OrderType = OrderType;
			CoNumType _CoNum = CoNum;
			CoTypeType _FROMOrderType = FROMOrderType;
			CoNumType _FROMCoNum = FROMCoNum;
			CoLineType _StartLineNum = StartLineNum;
			CoLineType _EndLineNum = EndLineNum;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateTargetCoNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FROMOrderType", _FROMOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMCoNum", _FROMCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoNum = _CoNum;
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
