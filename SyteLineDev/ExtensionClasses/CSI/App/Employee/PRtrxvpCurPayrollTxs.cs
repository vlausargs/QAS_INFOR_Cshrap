//PROJECT NAME: Employee
//CLASS NAME: PRtrxvpCurPayrollTxs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPRtrxvpCurPayrollTxs
	{
		(int? ReturnCode, string Infobar) PRtrxvpCurPayrollTxsSP(Guid? pSessionId,
		DateTime? pCheckDate,
		string pBankCode,
		string pStartDept,
		string pEndDept,
		string pStartEmpNum,
		string pEndEmpNum,
		string pEmpType,
		string Infobar,
		string PStartEmpCate = null,
		string PEndEmpCate = null);
	}
	
	public class PRtrxvpCurPayrollTxs : IPRtrxvpCurPayrollTxs
	{
		readonly IApplicationDB appDB;
		
		public PRtrxvpCurPayrollTxs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PRtrxvpCurPayrollTxsSP(Guid? pSessionId,
		DateTime? pCheckDate,
		string pBankCode,
		string pStartDept,
		string pEndDept,
		string pStartEmpNum,
		string pEndEmpNum,
		string pEmpType,
		string Infobar,
		string PStartEmpCate = null,
		string PEndEmpCate = null)
		{
			RowPointerType _pSessionId = pSessionId;
			DateType _pCheckDate = pCheckDate;
			BankCodeType _pBankCode = pBankCode;
			DeptType _pStartDept = pStartDept;
			DeptType _pEndDept = pEndDept;
			EmpNumType _pStartEmpNum = pStartEmpNum;
			EmpNumType _pEndEmpNum = pEndEmpNum;
			StringType _pEmpType = pEmpType;
			InfobarType _Infobar = Infobar;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRtrxvpCurPayrollTxsSP";
				
				appDB.AddCommandParameter(cmd, "pSessionId", _pSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckDate", _pCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDept", _pStartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDept", _pEndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartEmpNum", _pStartEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEmpNum", _pEndEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpType", _pEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
