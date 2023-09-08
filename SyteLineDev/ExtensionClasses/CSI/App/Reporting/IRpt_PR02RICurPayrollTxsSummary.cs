//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PR02RICurPayrollTxsSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PR02RICurPayrollTxsSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PR02RICurPayrollTxsSummarySp(string pSessionIDChar = null,
		string pStartDept = null,
		string pEndDept = null,
		string pStartEmpNum = null,
		string pEndEmpNum = null,
		DateTime? pCheckDate = null,
		string pBankCode = null,
		int? pCheckNum = null,
		int? pPrintZeroChecks = 0,
		int? pNewPrCheck = 0,
		string pEmpType = null,
		int? pPrintHeader = 0,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null);
	}
}

