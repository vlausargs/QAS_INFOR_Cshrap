//PROJECT NAME: Employee
//CLASS NAME: PrLogRefreshEmpDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PrLogRefreshEmpDefaults : IPrLogRefreshEmpDefaults
	{
		readonly IApplicationDB appDB;
		
		
		public PrLogRefreshEmpDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string EmpName,
		int? EmpSeq,
		string EmpShift,
		string Infobar) PrLogRefreshEmpDefaultsSp(string EmpNum,
		string EmpName,
		int? EmpSeq,
		string EmpShift,
		string Infobar)
		{
			EmpNumType _EmpNum = EmpNum;
			EmpNameType _EmpName = EmpName;
			PrLogSeqType _EmpSeq = EmpSeq;
			ShiftType _EmpShift = EmpShift;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrLogRefreshEmpDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpName", _EmpName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpSeq", _EmpSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpShift", _EmpShift, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmpName = _EmpName;
				EmpSeq = _EmpSeq;
				EmpShift = _EmpShift;
				Infobar = _Infobar;
				
				return (Severity, EmpName, EmpSeq, EmpShift, Infobar);
			}
		}
	}
}
