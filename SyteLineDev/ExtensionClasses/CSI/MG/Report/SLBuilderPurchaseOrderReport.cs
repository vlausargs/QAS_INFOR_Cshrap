//PROJECT NAME: ReportExt
//CLASS NAME: SLBuilderPurchaseOrderReport.cs

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
    [IDOExtensionClass("SLBuilderPurchaseOrderReport")]
    public class SLBuilderPurchaseOrderReport : ExtensionClassBase
    {
       
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_BuilderPurchaseOrderSp([Optional] Guid? process_id,
		[Optional] string pPoType,
		[Optional] string pPoStat,
		[Optional] string pPoitemStat,
		[Optional] byte? pPostFlag,
		[Optional] DateTime? pPODate,
		[Optional] int? pRoundPlaces,
		[Optional] string pPrintItemVI,
		[Optional] byte? pPrPoTxt,
		[Optional] byte? pPrPoBlnNote,
		[Optional] byte? pPrPoLineNote,
		[Optional] byte? pPrPoBlnDesc,
		[Optional] byte? pPrPoLineDesc,
		[Optional] byte? pPrPONote,
		[Optional] byte? pTransDomCurr,
		[Optional] byte? pPrintEuro,
		[Optional] string pStartBuilderPoNum,
		[Optional] string pEndBuilderPoNum,
		[Optional] short? pStartPoLine,
		[Optional] short? pEndPoLine,
		[Optional] short? pStartPoRElease,
		[Optional] short? pEndPoRelease,
		[Optional] DateTime? pStartDueDate,
		[Optional] DateTime? pEndDueDate,
		[Optional] string pStartvendor,
		[Optional] string pEndVendor,
		[Optional] DateTime? pStartorderDate,
		[Optional] DateTime? pEndOrderDate,
		[Optional] string pReviewPrint,
		[Optional] short? pPODateOffset,
		[Optional] short? pStartDueDateOffset,
		[Optional] short? pEndDueDateOffset,
		[Optional] short? pStartOrderDateOffset,
		[Optional] short? pEndOrderDateOffset,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowInternal,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowExternal,
		[Optional, DefaultParameterValue((byte)0)] byte? IncludeBlnsWOReleases,
		[Optional, DefaultParameterValue(null)] string orig_site,
		[Optional, DefaultParameterValue((byte)0)] byte? pPrintManufacturerItem,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_BuilderPurchaseOrderExt = new Rpt_BuilderPurchaseOrderFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_BuilderPurchaseOrderExt.Rpt_BuilderPurchaseOrderSp(process_id,
				                                                                     pPoType,
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
				                                                                     pStartBuilderPoNum,
				                                                                     pEndBuilderPoNum,
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
				                                                                     orig_site,
				                                                                     pPrintManufacturerItem,
				                                                                     BGSessionId,
				                                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
