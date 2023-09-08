//PROJECT NAME: CSIProjects
//CLASS NAME: prjresDupItemWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IprjresDupItemWarning
	{
		(int? ReturnCode, string Infobar, string Prompt, string PromptButtons) prjresDupItemWarningSp(string PProjNum,
		int? PTaskNum,
		int? PSeq,
		string PItem,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null);
	}
	
	public class prjresDupItemWarning : IprjresDupItemWarning
	{
		readonly IApplicationDB appDB;
		
		public prjresDupItemWarning(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string Prompt, string PromptButtons) prjresDupItemWarningSp(string PProjNum,
		int? PTaskNum,
		int? PSeq,
		string PItem,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeq = PSeq;
			ItemType _PItem = PItem;
			InfobarType _Infobar = Infobar;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "prjresDupItemWarningSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
