//PROJECT NAME: Employee
//CLASS NAME: PR01VRPVoidChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PR01VRPVoidChecks : IPR01VRPVoidChecks
	{
		readonly IApplicationDB appDB;
		
		
		public PR01VRPVoidChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? rUnpostedVoid,
		string Infobar) PR01VRPVoidChecksSp(Guid? pSessionId,
		decimal? pUserID,
		int? pCreateNew = 0,
		int? pCheckNum = null,
		int? pEndCheckNum = null,
		string pBankCode = null,
		string pStartDept = null,
		string pEndDept = null,
		string pStartEmpNum = null,
		string pEndEmpNum = null,
		int? pPrintZeroChecks = null,
		string pEmpType = null,
		int? rUnpostedVoid = null,
		string Infobar = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null)
		{
			RowPointerType _pSessionId = pSessionId;
			TokenType _pUserID = pUserID;
			FlagNyType _pCreateNew = pCreateNew;
			PrCheckNumType _pCheckNum = pCheckNum;
			PrCheckNumType _pEndCheckNum = pEndCheckNum;
			BankCodeType _pBankCode = pBankCode;
			DeptType _pStartDept = pStartDept;
			DeptType _pEndDept = pEndDept;
			EmpNumType _pStartEmpNum = pStartEmpNum;
			EmpNumType _pEndEmpNum = pEndEmpNum;
			FlagNyType _pPrintZeroChecks = pPrintZeroChecks;
			StringType _pEmpType = pEmpType;
			FlagNyType _rUnpostedVoid = rUnpostedVoid;
			InfobarType _Infobar = Infobar;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PR01VRPVoidChecksSp";
				
				appDB.AddCommandParameter(cmd, "pSessionId", _pSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUserID", _pUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreateNew", _pCreateNew, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCheckNum", _pEndCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDept", _pStartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDept", _pEndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartEmpNum", _pStartEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEmpNum", _pEndEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintZeroChecks", _pPrintZeroChecks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpType", _pEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rUnpostedVoid", _rUnpostedVoid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rUnpostedVoid = _rUnpostedVoid;
				Infobar = _Infobar;
				
				return (Severity, rUnpostedVoid, Infobar);
			}
		}
	}
}
