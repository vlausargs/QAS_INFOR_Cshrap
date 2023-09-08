//PROJECT NAME: Employee
//CLASS NAME: ICLM_PR01VRPVoidChecksRange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_PR01VRPVoidChecksRange
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PR01VRPVoidChecksRangeSp(string pBankCode,
		string pStartDept,
		string pEndDept,
		string pStartEmpNum,
		string pEndEmpNum,
		int? pPrintZeroChecks,
		string pEmpType,
		string PStartEmpCate = null,
		string PEndEmpCate = null);
	}
}

