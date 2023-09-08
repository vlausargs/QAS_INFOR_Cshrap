//PROJECT NAME: CSIProjects
//CLASS NAME: ProjmatlTransactionByContainer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjmatlTransactionByContainer
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) ProjmatlTransactionByContainerSp(string ContainerNum,
		string PProjNum = null,
		int? PTaskNum = null,
		string CurWhse = null,
		DateTime? PTransDate = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null);
	}
	
	public class ProjmatlTransactionByContainer : IProjmatlTransactionByContainer
	{
		readonly IApplicationDB appDB;
		
		public ProjmatlTransactionByContainer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons, string Infobar) ProjmatlTransactionByContainerSp(string ContainerNum,
		string PProjNum = null,
		int? PTaskNum = null,
		string CurWhse = null,
		DateTime? PTransDate = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null)
		{
			ContainerNumType _ContainerNum = ContainerNum;
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			WhseType _CurWhse = CurWhse;
			DateType _PTransDate = PTransDate;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjmatlTransactionByContainerSp";
				
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
