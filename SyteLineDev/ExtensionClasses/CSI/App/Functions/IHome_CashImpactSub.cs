//PROJECT NAME: Data
//CLASS NAME: IHome_CashImpactSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHome_CashImpactSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_CashImpactSubSp(
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
			int? TaskId = null);
	}
}

