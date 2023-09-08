//PROJECT NAME: CSIProjects
//CLASS NAME: ValidateTargetProjNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IValidateTargetProjNumForCopy
	{
		int ValidateTargetProjNumForCopySp(string ToProjType,
		                                   ref string ToProjNum,
		                                   string FromProjType,
		                                   string FromProjNum,
		                                   ref int? StartTaskNum,
		                                   ref int? EndTaskNum,
		                                   string CopyOption,
		                                   ref string Prompt,
		                                   ref string PromptButtons,
		                                   ref string Infobar);
	}
	
	public class ValidateTargetProjNumForCopy : IValidateTargetProjNumForCopy
	{
		readonly IApplicationDB appDB;
		
		public ValidateTargetProjNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateTargetProjNumForCopySp(string ToProjType,
		                                          ref string ToProjNum,
		                                          string FromProjType,
		                                          string FromProjNum,
		                                          ref int? StartTaskNum,
		                                          ref int? EndTaskNum,
		                                          string CopyOption,
		                                          ref string Prompt,
		                                          ref string PromptButtons,
		                                          ref string Infobar)
		{
			ProjTypeType _ToProjType = ToProjType;
			ProjNumType _ToProjNum = ToProjNum;
			ProjTypeType _FromProjType = FromProjType;
			ProjNumType _FromProjNum = FromProjNum;
			TaskNumType _StartTaskNum = StartTaskNum;
			TaskNumType _EndTaskNum = EndTaskNum;
			StringType _CopyOption = CopyOption;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateTargetProjNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "ToProjType", _ToProjType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProjNum", _ToProjNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromProjType", _FromProjType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProjNum", _FromProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTaskNum", _StartTaskNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndTaskNum", _EndTaskNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyOption", _CopyOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToProjNum = _ToProjNum;
				StartTaskNum = _StartTaskNum;
				EndTaskNum = _EndTaskNum;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
