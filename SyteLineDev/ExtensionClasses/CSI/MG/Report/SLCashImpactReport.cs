//PROJECT NAME: ReportExt
//CLASS NAME: SLCashImpactReport.cs

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
    [IDOExtensionClass("SLCashImpactReport")]
    public class SLCashImpactReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CashImpactSp([Optional] string SummaryOrDetail,
		                                  [Optional] string InclARTrxAPTrxOrBoth,
		                                  [Optional] string InclCOPOOrBoth,
		                                  [Optional] byte? InclPORequisitions,
		                                  [Optional] byte? InclCOBlanketReleases,
		                                  [Optional] byte? InclPOBlanketReleases,
		                                  [Optional] byte? InclCOProgresiveBilling,
		                                  [Optional] string CreditHold,
		                                  [Optional] byte? InclEstimateOrders,
		                                  [Optional] int? EstimateOrderOffsetDay,
		                                  [Optional] byte? InclAREarlyPayDiscounts,
		                                  [Optional] byte? InclAPEarlyPayDiscounts,
		                                  [Optional] string CustomerPaymentsBasis,
		                                  [Optional] int? NumberOfDaysLookback,
		                                  [Optional] byte? TranslateToDomesticCurrency,
		                                  [Optional] string StartingCurrencyCode,
		                                  [Optional] string EndingCurrencyCode,
		                                  [Optional] string PaymentHold,
		                                  [Optional] string EstimateStatus,
		                                  [Optional] int? NumberOfDaysPerColumn,
		                                  [Optional] byte? UseHistoricalCurrencyRate,
		                                  [Optional] byte? DisplayHeader,
		                                  [Optional] int? TaskId,
		                                  [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CashImpactExt = new Rpt_CashImpactFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CashImpactExt.Rpt_CashImpactSp(SummaryOrDetail,
				                                                 InclARTrxAPTrxOrBoth,
				                                                 InclCOPOOrBoth,
				                                                 InclPORequisitions,
				                                                 InclCOBlanketReleases,
				                                                 InclPOBlanketReleases,
				                                                 InclCOProgresiveBilling,
				                                                 CreditHold,
				                                                 InclEstimateOrders,
				                                                 EstimateOrderOffsetDay,
				                                                 InclAREarlyPayDiscounts,
				                                                 InclAPEarlyPayDiscounts,
				                                                 CustomerPaymentsBasis,
				                                                 NumberOfDaysLookback,
				                                                 TranslateToDomesticCurrency,
				                                                 StartingCurrencyCode,
				                                                 EndingCurrencyCode,
				                                                 PaymentHold,
				                                                 EstimateStatus,
				                                                 NumberOfDaysPerColumn,
				                                                 UseHistoricalCurrencyRate,
				                                                 DisplayHeader,
				                                                 TaskId,
				                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
