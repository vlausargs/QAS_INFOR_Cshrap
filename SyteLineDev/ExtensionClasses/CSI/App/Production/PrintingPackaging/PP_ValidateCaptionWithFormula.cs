//PROJECT NAME: CSIPPIndPack
//CLASS NAME: PP_ValidateCaptionWithFormula.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_ValidateCaptionWithFormula
	{
		(int? ReturnCode, string Infobar, string PromptMsg, string PromptButtons) PP_ValidateCaptionWithFormulaSp(string OperationType,
		string OldCaptionVal,
		string NewCaptionVal,
		string Infobar,
		string PromptMsg,
		string PromptButtons);
	}
	
	public class PP_ValidateCaptionWithFormula : IPP_ValidateCaptionWithFormula
	{
		readonly IApplicationDB appDB;
		
		public PP_ValidateCaptionWithFormula(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string PromptMsg, string PromptButtons) PP_ValidateCaptionWithFormulaSp(string OperationType,
		string OldCaptionVal,
		string NewCaptionVal,
		string Infobar,
		string PromptMsg,
		string PromptButtons)
		{
			PP_OperationType2Type _OperationType = OperationType;
			FormNameOrCaptionType _OldCaptionVal = OldCaptionVal;
			FormNameOrCaptionType _NewCaptionVal = NewCaptionVal;
			Infobar _Infobar = Infobar;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_ValidateCaptionWithFormulaSp";
				
				appDB.AddCommandParameter(cmd, "OperationType", _OperationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCaptionVal", _OldCaptionVal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCaptionVal", _NewCaptionVal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
