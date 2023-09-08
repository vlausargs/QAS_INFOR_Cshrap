//PROJECT NAME: Admin
//CLASS NAME: ValidateDept.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class ValidateDept : IValidateDept
	{
		IApplicationDB appDB;
		
		
		public ValidateDept(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DeptUnit,
		string DlAcct,
		string DlAcctUnit2,
		string DlAcctUnit3,
		string DlAcctUnit4,
		string Infobar) ValidateDeptSp(string Dept,
		string EmpNum,
		string DeptUnit,
		string DlAcct,
		string DlAcctUnit2,
		string DlAcctUnit3,
		string DlAcctUnit4,
		string Infobar)
		{
			DeptType _Dept = Dept;
			EmpNumType _EmpNum = EmpNum;
			UnitCode1Type _DeptUnit = DeptUnit;
			AcctType _DlAcct = DlAcct;
			UnitCode2Type _DlAcctUnit2 = DlAcctUnit2;
			UnitCode3Type _DlAcctUnit3 = DlAcctUnit3;
			UnitCode4Type _DlAcctUnit4 = DlAcctUnit4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateDeptSp";
				
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeptUnit", _DeptUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DlAcct", _DlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DlAcctUnit2", _DlAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DlAcctUnit3", _DlAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DlAcctUnit4", _DlAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DeptUnit = _DeptUnit;
				DlAcct = _DlAcct;
				DlAcctUnit2 = _DlAcctUnit2;
				DlAcctUnit3 = _DlAcctUnit3;
				DlAcctUnit4 = _DlAcctUnit4;
				Infobar = _Infobar;
				
				return (Severity, DeptUnit, DlAcct, DlAcctUnit2, DlAcctUnit3, DlAcctUnit4, Infobar);
			}
		}
	}
}
