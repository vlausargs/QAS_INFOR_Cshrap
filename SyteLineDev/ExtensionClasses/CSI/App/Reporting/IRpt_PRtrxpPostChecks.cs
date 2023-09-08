//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PRtrxpPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PRtrxpPostChecks
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PRtrxpPostChecksSp(string pSessionIDChar = null,
		string pStartDept = null,
		string pEndDept = null,
		string pStartEmpNum = null,
		string pEndEmpNum = null,
		string pBankCode = null,
		string pEmpType = null,
		int? pPrintHeader = null,
		string BGSessionId = null,
		DateTime? pCheckDate = null,
		int? pCheckNum = null,
		int? pPrintZeroChecks = 0,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null);
	}
}

