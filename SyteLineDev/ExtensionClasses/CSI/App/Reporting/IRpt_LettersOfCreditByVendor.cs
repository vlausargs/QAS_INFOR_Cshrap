//PROJECT NAME: Reporting
//CLASS NAME: IRpt_LettersOfCreditByVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_LettersOfCreditByVendor
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_LettersOfCreditByVendorSp(string pLcrStat = "POEC",
		string pCurrCode = null,
		int? pShowDetail = 0,
		string pStartVendor = null,
		string pEndVendor = null,
		string pStartVendLcrNum = null,
		string pEndVendLcrNum = null,
		DateTime? pStartIssueDate = null,
		DateTime? pEndIssueDate = null,
		DateTime? pStartEstCloseDate = null,
		DateTime? pEndEstCloseDate = null,
		int? pStartIssueDateOffset = null,
		int? pEndIssueDateOffset = null,
		int? pStartEstCloseDateOffset = null,
		int? pEndEstCloseDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

