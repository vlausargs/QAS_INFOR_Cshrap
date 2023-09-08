//PROJECT NAME: Employee
//CLASS NAME: SVacSetDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface ISVacSetDefault
	{
		(int? ReturnCode, byte? VacationActive, decimal? VacationDaysEarned, string Infobar) SVacSetDefaultSp(string pEmpNum,
		string DateMethod = "F",
		DateTime? FixedDate = null,
		byte? VacationActive = null,
		decimal? VacationDaysEarned = null,
		string Infobar = null);
	}
	
	public class SVacSetDefault : ISVacSetDefault
	{
		readonly IApplicationDB appDB;
		
		public SVacSetDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? VacationActive, decimal? VacationDaysEarned, string Infobar) SVacSetDefaultSp(string pEmpNum,
		string DateMethod = "F",
		DateTime? FixedDate = null,
		byte? VacationActive = null,
		decimal? VacationDaysEarned = null,
		string Infobar = null)
		{
			EmpNumType _pEmpNum = pEmpNum;
			StringType _DateMethod = DateMethod;
			DateType _FixedDate = FixedDate;
			ListYesNoType _VacationActive = VacationActive;
			DaysOffType _VacationDaysEarned = VacationDaysEarned;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SVacSetDefaultSp";
				
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateMethod", _DateMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixedDate", _FixedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VacationActive", _VacationActive, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VacationDaysEarned", _VacationDaysEarned, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VacationActive = _VacationActive;
				VacationDaysEarned = _VacationDaysEarned;
				Infobar = _Infobar;
				
				return (Severity, VacationActive, VacationDaysEarned, Infobar);
			}
		}
	}
}
