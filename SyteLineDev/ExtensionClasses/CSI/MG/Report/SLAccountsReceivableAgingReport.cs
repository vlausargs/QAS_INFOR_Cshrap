//PROJECT NAME: ReportExt
//CLASS NAME: SLAccountsReceivableAgingReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLAccountsReceivableAgingReport")]
    public class SLAccountsReceivableAgingReport : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_AccountsReceivableAgingSp([Optional] DateTime? AgingDate,
			[Optional] DateTime? CutoffDate,
			[Optional] int? AgingDateOffset,
			[Optional] int? CutoffDateOffset,
			[Optional] string StateCycle,
			[Optional] int? ShowActive,
			[Optional] string BegSlsman,
			[Optional] string EndSlsman,
			[Optional] string CustomerStarting,
			[Optional] string CustomerEnding,
			[Optional] string NameStarting,
			[Optional] string NameEnding,
			[Optional] string CurCodeStarting,
			[Optional] string CurCodeEnding,
			[Optional] int? PrZeroBal,
			[Optional] string CreditHold,
			[Optional] int? PrCreditBal,
			[Optional] int? SumToCorp,
			[Optional] int? TransDomCurr,
			[Optional] int? UseHistRate,
			[Optional] string PrOpenItem,
			[Optional] int? PrOpenPay,
			[Optional] int? HidePaid,
			[Optional] int? SortByCurr,
			[Optional] string ArSortBy,
			[Optional] string AgeBuckets,
			[Optional] string InvDue,
			[Optional] int? AgeDays1,
			[Optional] string AgeDesc1,
			[Optional] int? AgeDays2,
			[Optional] string AgeDesc2,
			[Optional] int? AgeDays3,
			[Optional] string AgeDesc3,
			[Optional] int? AgeDays4,
			[Optional] string AgeDesc4,
			[Optional] int? AgeDays5,
			[Optional] string AgeDesc5,
			[Optional] string SiteGroup,
			[Optional] int? DisplayHeader,
			[Optional] int? ConsolidateCustomers,
			[Optional] int? IncludeEstCurrGainLossAmtsInTotals,
			[Optional] string pSite,
            [Optional] Guid? pProcessId)
		{
			var iRpt_AccountsReceivableAgingExt = new Rpt_AccountsReceivableAgingFactory().Create(this, true);
			
			var result = iRpt_AccountsReceivableAgingExt.Rpt_AccountsReceivableAgingSp(AgingDate,
				CutoffDate,
				AgingDateOffset,
				CutoffDateOffset,
				StateCycle,
				ShowActive,
				BegSlsman,
				EndSlsman,
				CustomerStarting,
				CustomerEnding,
				NameStarting,
				NameEnding,
				CurCodeStarting,
				CurCodeEnding,
				PrZeroBal,
				CreditHold,
				PrCreditBal,
				SumToCorp,
				TransDomCurr,
				UseHistRate,
				PrOpenItem,
				PrOpenPay,
				HidePaid,
				SortByCurr,
				ArSortBy,
				AgeBuckets,
				InvDue,
				AgeDays1,
				AgeDesc1,
				AgeDays2,
				AgeDesc2,
				AgeDays3,
				AgeDesc3,
				AgeDays4,
				AgeDesc4,
				AgeDays5,
				AgeDesc5,
				SiteGroup,
				DisplayHeader,
				ConsolidateCustomers,
				IncludeEstCurrGainLossAmtsInTotals,
				pSite,
				pProcessId);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
    }
}
