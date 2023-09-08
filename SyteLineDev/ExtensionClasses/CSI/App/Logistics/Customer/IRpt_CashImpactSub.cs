//PROJECT NAME: Logistics.Customer
//CLASS NAME: IRpt_CashImpactSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IRpt_CashImpactSub
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CashImpactSubSp(
            string SummaryOrDetail = null,
            string InclARTrxAPTrxOrBoth = null,
            string InclCOPOOrBoth = null,
            int? InclPORequisitions = null,
            int? InclCOBlanketReleases = null,
            int? InclPOBlanketReleases = null,
            int? InclCOProgresiveBilling = null,
            string CreditHold = null,
            int? InclEstimateOrders = null,
            int? EstimateOrderOffsetDay = null,
            int? InclAREarlyPayDiscounts = null,
            int? InclAPEarlyPayDiscounts = null,
            string CustomerPaymentsBasis = null,
            int? NumberOfDaysLookback = null,
            int? TranslateToDomesticCurrency = null,
            string StartingCurrencyCode = null,
            string EndingCurrencyCode = null,
            string PaymentHold = null,
            string EstimateStatus = null,
            int? NumberOfDaysPerColumn = null,
            int? UseHistoricalCurrencyRate = null,
            int? DisplayHeader = null,
            int? TaskId = null,
            int? OnlyNeedTotals = 1);
    }
}

