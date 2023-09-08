//PROJECT NAME: Employee
//CLASS NAME: IPR01VRPVoidChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPR01VRPVoidChecks
	{
		(int? ReturnCode, int? rUnpostedVoid,
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
		string PEndEmpCate = null);
	}
}

