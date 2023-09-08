//PROJECT NAME: ReportExt
//CLASS NAME: SLConsolidatedInvoicingReport.cs

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
	[IDOExtensionClass("SLConsolidatedInvoicingReport")]
	public class SLConsolidatedInvoicingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ConsolidatedInvoicingSp([Optional] string pSessionIdChar,
		[Optional, DefaultParameterValue("REPRINT")] string pMode,
		[Optional] string pBegCustNum,
		[Optional] string pEndCustNum,
		[Optional] string pBegDoNum,
		[Optional] string pEndDoNum,
		[Optional] string pBegCustPo,
		[Optional] string pEndCustPo,
		[Optional] string pBegInvNum,
		[Optional] string pEndInvNum,
		[Optional] DateTime? pBegInvoiceDate,
		[Optional] DateTime? pEndInvoiceDate,
		[Optional, DefaultParameterValue("CI")] string pItemType,
		[Optional, DefaultParameterValue("I")] string pInvoiceOrCreditMemo,
		[Optional, DefaultParameterValue("E")] string pConfigurationDetails,
		[Optional, DefaultParameterValue("RB")] string pInvoiceType,
		[Optional, DefaultParameterValue(0)] int? pEuroTotal,
		[Optional, DefaultParameterValue(0)] int? pTranslateToDomestic,
		[Optional, DefaultParameterValue(1)] int? PrintSerialNumbers,
		[Optional, DefaultParameterValue(0)] int? pPlanningItemMaterials,
		[Optional, DefaultParameterValue(1)] int? pLCR,
		[Optional, DefaultParameterValue(0)] int? pOrderNumbers,
		[Optional, DefaultParameterValue(0)] int? PrintOrderLineNotes,
		[Optional, DefaultParameterValue(0)] int? PrintLineReleaseDescription,
		[Optional, DefaultParameterValue(0)] int? PrintStandardOrderText,
		[Optional, DefaultParameterValue(0)] int? PrintBillToNotes,
		[Optional, DefaultParameterValue(1)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(1)] int? PrintExternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintItemOverview,
		[Optional, DefaultParameterValue(0)] int? PrintDiscountAmt,
		[Optional, DefaultParameterValue(1)] int? PrintLotNumbers,
		[Optional] decimal? pBegShipment,
		[Optional] decimal? pEndShipment,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ConsolidatedInvoicingExt = new Rpt_ConsolidatedInvoicingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ConsolidatedInvoicingExt.Rpt_ConsolidatedInvoicingSp(pSessionIdChar,
				pMode,
				pBegCustNum,
				pEndCustNum,
				pBegDoNum,
				pEndDoNum,
				pBegCustPo,
				pEndCustPo,
				pBegInvNum,
				pEndInvNum,
				pBegInvoiceDate,
				pEndInvoiceDate,
				pItemType,
				pInvoiceOrCreditMemo,
				pConfigurationDetails,
				pInvoiceType,
				pEuroTotal,
				pTranslateToDomestic,
				PrintSerialNumbers,
				pPlanningItemMaterials,
				pLCR,
				pOrderNumbers,
				PrintOrderLineNotes,
				PrintLineReleaseDescription,
				PrintStandardOrderText,
				PrintBillToNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				PrintItemOverview,
				PrintDiscountAmt,
				PrintLotNumbers,
				pBegShipment,
				pEndShipment,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
