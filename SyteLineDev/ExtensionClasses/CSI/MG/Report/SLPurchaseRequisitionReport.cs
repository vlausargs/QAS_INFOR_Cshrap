//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchaseRequisitionReport.cs

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
    [IDOExtensionClass("SLPurchaseRequisitionReport")]
    public class SLPurchaseRequisitionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchaseRequisitionSp([Optional] string PreqStat,
		[Optional] string PPreqItemStat,
		[Optional] int? PrintReqNotes,
		[Optional] int? PrintLineNotes,
		[Optional] int? ShowExternal,
		[Optional] int? ShowInternal,
		[Optional] string PreqNumStarting,
		[Optional] string PreqNumEnding,
		[Optional] int? PreqItemStarting,
		[Optional] int? PreqItemEnding,
		[Optional] DateTime? PreqItemDueDateStarting,
		[Optional] DateTime? PreqItemDueDateEnding,
		[Optional] int? PreqItemDueDateStartingOffset,
		[Optional] int? PreqItemDueDateEndingOffset,
		[Optional] string PreqItemVendNumStarting,
		[Optional] string PreqItemVendNumEnding,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PurchaseRequisitionExt = new Rpt_PurchaseRequisitionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PurchaseRequisitionExt.Rpt_PurchaseRequisitionSp(PreqStat,
				PPreqItemStat,
				PrintReqNotes,
				PrintLineNotes,
				ShowExternal,
				ShowInternal,
				PreqNumStarting,
				PreqNumEnding,
				PreqItemStarting,
				PreqItemEnding,
				PreqItemDueDateStarting,
				PreqItemDueDateEnding,
				PreqItemDueDateStartingOffset,
				PreqItemDueDateEndingOffset,
				PreqItemVendNumStarting,
				PreqItemVendNumEnding,
				PrintCost,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
