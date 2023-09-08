//PROJECT NAME: Employee
//CLASS NAME: SVac.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class SVac : ISVac
	{
		readonly IApplicationDB appDB;
		
		
		public SVac(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? VacationActive,
		decimal? VacationDaysEarned,
		DateTime? VacationLastUpdate,
		string Infobar) SVacSp(string pEmpNum,
		decimal? VacationDaysReimbursed,
		decimal? VacationDaysLytd,
		decimal? VacationDaysUsed,
		int? VacationActive,
		decimal? VacationDaysEarned,
		DateTime? VacationLastUpdate,
		string Infobar)
		{
			EmpNumType _pEmpNum = pEmpNum;
			DaysOffType _VacationDaysReimbursed = VacationDaysReimbursed;
			DaysCarriedForwardType _VacationDaysLytd = VacationDaysLytd;
			DaysOffType _VacationDaysUsed = VacationDaysUsed;
			ListYesNoType _VacationActive = VacationActive;
			DaysOffType _VacationDaysEarned = VacationDaysEarned;
			DateType _VacationLastUpdate = VacationLastUpdate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SVacSp";
				
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VacationDaysReimbursed", _VacationDaysReimbursed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VacationDaysLytd", _VacationDaysLytd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VacationDaysUsed", _VacationDaysUsed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VacationActive", _VacationActive, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VacationDaysEarned", _VacationDaysEarned, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VacationLastUpdate", _VacationLastUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VacationActive = _VacationActive;
				VacationDaysEarned = _VacationDaysEarned;
				VacationLastUpdate = _VacationLastUpdate;
				Infobar = _Infobar;
				
				return (Severity, VacationActive, VacationDaysEarned, VacationLastUpdate, Infobar);
			}
		}
	}
}
