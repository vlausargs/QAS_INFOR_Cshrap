//PROJECT NAME: CSIEmployee
//CLASS NAME: PR01crpDoChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IPR01crpDoChecks
	{
		(int? ReturnCode, byte? rTPostNeeded, string Infobar) PR01crpDoChecksSp(Guid? pSessionID = null,
		int? pCheckNum = null,
		string pStartDept = null,
		string pEndDept = null,
		string pStartEmpNum = null,
		string pEndEmpNum = null,
		DateTime? pCheckDate = null,
		string pBankCode = null,
		byte? pPrintZeroChecks = null,
		string pEmpType = null,
		byte? rTPostNeeded = null,
		string Infobar = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null);
	}
	
	public class PR01crpDoChecks : IPR01crpDoChecks
	{
		readonly IApplicationDB appDB;
		
		public PR01crpDoChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? rTPostNeeded, string Infobar) PR01crpDoChecksSp(Guid? pSessionID = null,
		int? pCheckNum = null,
		string pStartDept = null,
		string pEndDept = null,
		string pStartEmpNum = null,
		string pEndEmpNum = null,
		DateTime? pCheckDate = null,
		string pBankCode = null,
		byte? pPrintZeroChecks = null,
		string pEmpType = null,
		byte? rTPostNeeded = null,
		string Infobar = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null)
		{
			RowPointerType _pSessionID = pSessionID;
			PrCheckNumType _pCheckNum = pCheckNum;
			DeptType _pStartDept = pStartDept;
			DeptType _pEndDept = pEndDept;
			EmpNumType _pStartEmpNum = pStartEmpNum;
			EmpNumType _pEndEmpNum = pEndEmpNum;
			DateType _pCheckDate = pCheckDate;
			BankCodeType _pBankCode = pBankCode;
			ListYesNoType _pPrintZeroChecks = pPrintZeroChecks;
			StringType _pEmpType = pEmpType;
			ListYesNoType _rTPostNeeded = rTPostNeeded;
			InfobarType _Infobar = Infobar;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PR01crpDoChecksSp";
				
				appDB.AddCommandParameter(cmd, "pSessionID", _pSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDept", _pStartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDept", _pEndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartEmpNum", _pStartEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEmpNum", _pEndEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckDate", _pCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintZeroChecks", _pPrintZeroChecks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpType", _pEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rTPostNeeded", _rTPostNeeded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rTPostNeeded = _rTPostNeeded;
				Infobar = _Infobar;
				
				return (Severity, rTPostNeeded, Infobar);
			}
		}
	}
}
