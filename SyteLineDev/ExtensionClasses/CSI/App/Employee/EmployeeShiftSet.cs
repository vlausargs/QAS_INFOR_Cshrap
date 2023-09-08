//PROJECT NAME: Employee
//CLASS NAME: EmployeeShiftSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class EmployeeShiftSet : IEmployeeShiftSet
	{
		readonly IApplicationDB appDB;
		
		
		public EmployeeShiftSet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EmployeeShiftSetSp(string EmpNum,
		string Shift)
		{
			EmpNumType _EmpNum = EmpNum;
			ShiftType _Shift = Shift;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EmployeeShiftSetSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
