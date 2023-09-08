//PROJECT NAME: Reporting
//CLASS NAME: IAging.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IAging
    {
        (int? ReturnCode,
            int? TGrand,
            int? FirstOfCustomer,
            int? UseHistRate,
            int? TranslateForAging,
            string SiteLabel,
            int? TTransDom,
            int? AnyTrans) AgingSp(
            int? ConsolidateCustomers,
            string PSite,
            string PPrOpenItem,
            DateTime? PAgingDate,
            int? PSumToCorp,
            string PSSlsman,
            string PESlsman,
            string PStateCycle,
            string PCreditHold,
            int? PShowActive,
            int? PPrZeroBal,
            int? PPrCreditBal,
            int? PSortByCurr,
            int? PPrOpenPay,
            DateTime? PCutoffDate,
            string PInvDue,
            int? PAgeDays1,
            int? PAgeDays2,
            int? PAgeDays3,
            int? PAgeDays4,
            int? PAgeDays5,
            int? PHidePaid,
            string PAgeBucket,
            int? TGrand,
            int? FirstOfCustomer,
            int? UseHistRate,
            int? TranslateForAging,
            string SiteLabel,
            int? TTransDom,
            string CurCustNum,
            int? AnyTrans,
            string PAgeDesc1,
            string PAgeDesc2,
            string PAgeDesc3,
            string PAgeDesc4,
            string PAgeDesc5,
            string PArSortBy,
            Guid? ProcessID,
            int? IncludeEstCurrGainLossAmtsInTotals);
    }
}

