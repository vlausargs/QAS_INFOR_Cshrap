//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchaseOrderReport.cs

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
	[IDOExtensionClass("SLPurchaseOrderReport")]
	public class SLPurchaseOrderReport : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchaseOrderSp([Optional] string pPoType,
		[Optional] string pPoStat,
		[Optional] string pPoitemStat,
		[Optional] int? pPostFlag,
		[Optional] DateTime? pPODate,
		[Optional] int? pRoundPlaces,
		[Optional] string pPrintItemVI,
		[Optional] int? pPrPoTxt,
		[Optional] int? pPrPoBlnNote,
		[Optional] int? pPrPoLineNote,
		[Optional] int? pPrPoBlnDesc,
		[Optional] int? pPrPoLineDesc,
		[Optional] int? pPrPONote,
		[Optional] int? pTransDomCurr,
		[Optional] int? pPrintEuro,
		[Optional] string pStartPoNum,
		[Optional] string pEndPoNum,
		[Optional] int? pStartPoLine,
		[Optional] int? pEndPoLine,
		[Optional] int? pStartPoRElease,
		[Optional] int? pEndPoRelease,
		[Optional] DateTime? pStartDueDate,
		[Optional] DateTime? pEndDueDate,
		[Optional] string pStartvendor,
		[Optional] string pEndVendor,
		[Optional] DateTime? pStartorderDate,
		[Optional] DateTime? pEndOrderDate,
		[Optional] string pReviewPrint,
		[Optional] int? pPODateOffset,
		[Optional] int? pStartDueDateOffset,
		[Optional] int? pEndDueDateOffset,
		[Optional] int? pStartOrderDateOffset,
		[Optional] int? pEndOrderDateOffset,
		[Optional, DefaultParameterValue(1)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional, DefaultParameterValue(0)] int? IncludeBlnsWOReleases,
		[Optional] string FmSessionId,
		[Optional, DefaultParameterValue(0)] int? pPrintManufacturerItem,
		[Optional] decimal? UserID,
		[Optional] int? TaskID,
		[Optional] string BGSessionId,
		[Optional] string pSite,
		[Optional, DefaultParameterValue(0)] int? pPrintDrawingNumber,
		[Optional, DefaultParameterValue(0)] int? pPrintDeliveryIncoTerms,
		[Optional, DefaultParameterValue(0)] int? pPrintEUCode,
		[Optional, DefaultParameterValue(0)] int? pPrintOriginCode,
		[Optional, DefaultParameterValue(0)] int? pPrintCommodityCode,
		[Optional, DefaultParameterValue(0)] int? pPrintHeaderOnAllPages,
		[Optional, DefaultParameterValue(0)] int? pPrintAuthorizationSignatures,
		[Optional, DefaultParameterValue(0)] int? pPrintItemOverview,
		[Optional] int? ProfileExists,
		[Optional] int? UseProfile,
		[Optional] string Method,
		[Optional] string Destination)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PurchaseOrderExt = new Rpt_PurchaseOrderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PurchaseOrderExt.Rpt_PurchaseOrderSp(pPoType,
				pPoStat,
				pPoitemStat,
				pPostFlag,
				pPODate,
				pRoundPlaces,
				pPrintItemVI,
				pPrPoTxt,
				pPrPoBlnNote,
				pPrPoLineNote,
				pPrPoBlnDesc,
				pPrPoLineDesc,
				pPrPONote,
				pTransDomCurr,
				pPrintEuro,
				pStartPoNum,
				pEndPoNum,
				pStartPoLine,
				pEndPoLine,
				pStartPoRElease,
				pEndPoRelease,
				pStartDueDate,
				pEndDueDate,
				pStartvendor,
				pEndVendor,
				pStartorderDate,
				pEndOrderDate,
				pReviewPrint,
				pPODateOffset,
				pStartDueDateOffset,
				pEndDueDateOffset,
				pStartOrderDateOffset,
				pEndOrderDateOffset,
				ShowInternal,
				ShowExternal,
				IncludeBlnsWOReleases,
				FmSessionId,
				pPrintManufacturerItem,
				UserID,
				TaskID,
				BGSessionId,
				pSite,
				pPrintDrawingNumber,
				pPrintDeliveryIncoTerms,
				pPrintEUCode,
				pPrintOriginCode,
				pPrintCommodityCode,
				pPrintHeaderOnAllPages,
				pPrintAuthorizationSignatures,
				pPrintItemOverview,
				ProfileExists,
				UseProfile,
				Method,
				Destination);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SubTaxCodePurchaseOrderSp([Optional] string pPoNumStart,
		[Optional] string pPoNumEnd,
		[Optional, DefaultParameterValue(0)] int? pSummary,
		[Optional] string pSubTaxXMLData)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SubTaxCodePurchaseOrderExt = new Rpt_SubTaxCodePurchaseOrderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SubTaxCodePurchaseOrderExt.Rpt_SubTaxCodePurchaseOrderSp(pPoNumStart,
				pPoNumEnd,
				pSummary,
				pSubTaxXMLData);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
