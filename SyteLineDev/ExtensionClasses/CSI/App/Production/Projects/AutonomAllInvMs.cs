//PROJECT NAME: CSIProjects
//CLASS NAME: AutonomAllInvMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IAutonomAllInvMs
	{
		int AutonomAllInvMsSp(string ProjNum,
		                      ref byte? Refresh,
		                      ref string PromptMsg,
		                      ref string PromptButtons,
		                      ref string Infobar);
	}
	
	public class AutonomAllInvMs : IAutonomAllInvMs
	{
		readonly IApplicationDB appDB;
		
		public AutonomAllInvMs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int AutonomAllInvMsSp(string ProjNum,
		                             ref byte? Refresh,
		                             ref string PromptMsg,
		                             ref string PromptButtons,
		                             ref string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			ListYesNoType _Refresh = Refresh;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutonomAllInvMsSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Refresh", _Refresh, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Refresh = _Refresh;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
