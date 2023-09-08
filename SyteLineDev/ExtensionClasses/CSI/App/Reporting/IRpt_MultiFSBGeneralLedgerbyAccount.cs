//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBGeneralLedgerbyAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBGeneralLedgerbyAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBGeneralLedgerbyAccountSp(DateTime? SPerDate = null,
		DateTime? EPerDate = null,
		int? ShowAllTrx = null,
		string SortByTrx = null,
		string SecondSortBy = null,
		int? ShowDetail = null,
		int? AnalyticalLedger = null,
		string ChartType = null,
		string SAcct = null,
		string EAcct = null,
		string SiteGroup = null,
		int? SPerDateOffset = null,
		int? EPerDateOffset = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string PSAcctUnit1 = null,
		string PEAcctUnit1 = null,
		string PSAcctUnit2 = null,
		string PEAcctUnit2 = null,
		string PSAcctUnit3 = null,
		string PEAcctUnit3 = null,
		string PSAcctUnit4 = null,
		string PEAcctUnit4 = null,
		string FirstUnitSort = null,
		string SecondUnitSort = null,
		string ThirdUnitSort = null,
		string FourthUnitSort = null,
		string FSBName = null,
		string pSite = null);
	}
}

