//PROJECT NAME: Reporting
//CLASS NAME: IRpt_AccountsReceivableAging.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_AccountsReceivableAging
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_AccountsReceivableAgingSp(
			DateTime? AgingDate = null,
			DateTime? CutoffDate = null,
			int? AgingDateOffset = null,
			int? CutoffDateOffset = null,
			string StateCycle = null,
			int? ShowActive = null,
			string BegSlsman = null,
			string EndSlsman = null,
			string CustomerStarting = null,
			string CustomerEnding = null,
			string NameStarting = null,
			string NameEnding = null,
			string CurCodeStarting = null,
			string CurCodeEnding = null,
			int? PrZeroBal = null,
			string CreditHold = null,
			int? PrCreditBal = null,
			int? SumToCorp = null,
			int? TransDomCurr = null,
			int? UseHistRate = null,
			string PrOpenItem = null,
			int? PrOpenPay = null,
			int? HidePaid = null,
			int? SortByCurr = null,
			string ArSortBy = null,
			string AgeBuckets = null,
			string InvDue = null,
			int? AgeDays1 = null,
			string AgeDesc1 = null,
			int? AgeDays2 = null,
			string AgeDesc2 = null,
			int? AgeDays3 = null,
			string AgeDesc3 = null,
			int? AgeDays4 = null,
			string AgeDesc4 = null,
			int? AgeDays5 = null,
			string AgeDesc5 = null,
			string SiteGroup = null,
			int? DisplayHeader = null,
			int? ConsolidateCustomers = null,
			int? IncludeEstCurrGainLossAmtsInTotals = null,
			string pSite = null,
            Guid? pProcessId = null);
	}
}

