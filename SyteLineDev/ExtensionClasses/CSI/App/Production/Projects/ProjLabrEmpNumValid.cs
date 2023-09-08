//PROJECT NAME: CSIProjects
//CLASS NAME: ProjLabrEmpNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjLabrEmpNumValid
	{
		int ProjLabrEmpNumValidSp(string EmpNum,
		                          ref string EmpName,
		                          ref string Shift,
		                          ref decimal? TotalAHours,
		                          ref string Infobar,
		                          ref string PromptMessage,
		                          ref string PromptButtons);
	}
	
	public class ProjLabrEmpNumValid : IProjLabrEmpNumValid
	{
		readonly IApplicationDB appDB;
		
		public ProjLabrEmpNumValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjLabrEmpNumValidSp(string EmpNum,
		                                 ref string EmpName,
		                                 ref string Shift,
		                                 ref decimal? TotalAHours,
		                                 ref string Infobar,
		                                 ref string PromptMessage,
		                                 ref string PromptButtons)
		{
			EmpNumType _EmpNum = EmpNum;
			EmpNameType _EmpName = EmpName;
			ShiftType _Shift = Shift;
			TotalHoursType _TotalAHours = TotalAHours;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMessage = PromptMessage;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjLabrEmpNumValidSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpName", _EmpName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalAHours", _TotalAHours, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMessage", _PromptMessage, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmpName = _EmpName;
				Shift = _Shift;
				TotalAHours = _TotalAHours;
				Infobar = _Infobar;
				PromptMessage = _PromptMessage;
				PromptButtons = _PromptButtons;
				
				return Severity;
			}
		}
	}
}
