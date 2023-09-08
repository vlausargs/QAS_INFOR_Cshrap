//PROJECT NAME: Employee
//CLASS NAME: HrvacDoProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class HrvacDoProcess : IHrvacDoProcess
	{
		readonly IApplicationDB appDB;
		
		
		public HrvacDoProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) HrvacDoProcessSp(string pBegEmpNum,
		string pEndEmpNum,
		string DateMethod = "F",
		DateTime? FixedDate = null,
		string Infobar = null)
		{
			EmpNumType _pBegEmpNum = pBegEmpNum;
			EmpNumType _pEndEmpNum = pEndEmpNum;
			StringType _DateMethod = DateMethod;
			DateType _FixedDate = FixedDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HrvacDoProcessSp";
				
				appDB.AddCommandParameter(cmd, "pBegEmpNum", _pBegEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEmpNum", _pEndEmpNum, ParameterDirection.Input);
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
