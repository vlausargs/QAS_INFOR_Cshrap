//PROJECT NAME: Employee
//CLASS NAME: DeleteExportEmpLogData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class DeleteExportEmpLogData : IDeleteExportEmpLogData
	{
		readonly IApplicationDB appDB;
		
		
		public DeleteExportEmpLogData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteExportEmpLogDataSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum)
		{
			DeptType _StartingDept = StartingDept;
			DeptType _EndingDept = EndingDept;
			EmpNumType _StartingEmpNum = StartingEmpNum;
			EmpNumType _EndingEmpNum = EndingEmpNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteExportEmpLogDataSp";
				
				appDB.AddCommandParameter(cmd, "StartingDept", _StartingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDept", _EndingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingEmpNum", _StartingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingEmpNum", _EndingEmpNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
