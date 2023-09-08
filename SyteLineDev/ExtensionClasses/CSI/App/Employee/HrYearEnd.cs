//PROJECT NAME: Employee
//CLASS NAME: HrYearEnd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class HrYearEnd : IHrYearEnd
	{
		readonly IApplicationDB appDB;
		
		
		public HrYearEnd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) HrYearEndSp(string StartingEmpNum = null,
		string EndingEmpNum = null,
		string DateMethod = "F",
		DateTime? FixedDate = null,
		string Infobar = null)
		{
			EmpNumType _StartingEmpNum = StartingEmpNum;
			EmpNumType _EndingEmpNum = EndingEmpNum;
			StringType _DateMethod = DateMethod;
			DateType _FixedDate = FixedDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HrYearEndSp";
				
				appDB.AddCommandParameter(cmd, "StartingEmpNum", _StartingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingEmpNum", _EndingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateMethod", _DateMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixedDate", _FixedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
