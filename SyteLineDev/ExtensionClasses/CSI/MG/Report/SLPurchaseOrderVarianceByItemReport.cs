//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchaseOrderVarianceByItemReport.cs

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
    [IDOExtensionClass("SLPurchaseOrderVarianceByItemReport")]
    public class SLPurchaseOrderVarianceByItemReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchaseOrderVariancebyItemSp([Optional] string StartingItem,
		[Optional] string EndingItem,
		[Optional] string POType,
		[Optional] string POStatus,
		[Optional] string POLineRelStatus,
		[Optional] decimal? ToleranceFactor,
		[Optional] int? TransDomCurr,
		[Optional] DateTime? StartingDueDate,
		[Optional] DateTime? EndingDueDate,
		[Optional] int? StartingDueDateOffset,
		[Optional] int? EndingDueDateOffset,
		[Optional] DateTime? StartingLastRcvdDate,
		[Optional] DateTime? EndingLastRcvdDate,
		[Optional] int? StartingLastRcvdDateOffset,
		[Optional] int? EndingLastRcvdDateOffset,
		[Optional] string StartingPO,
		[Optional] string EndingPO,
		[Optional] string StartingVendor,
		[Optional] string EndingVendor,
		[Optional] DateTime? StartingOrderDate,
		[Optional] DateTime? EndingOrderDate,
		[Optional] int? StartingOrderDateOffset,
		[Optional] int? EndingOrderDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PurchaseOrderVariancebyItemExt = new Rpt_PurchaseOrderVariancebyItemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PurchaseOrderVariancebyItemExt.Rpt_PurchaseOrderVariancebyItemSp(StartingItem,
				EndingItem,
				POType,
				POStatus,
				POLineRelStatus,
				ToleranceFactor,
				TransDomCurr,
				StartingDueDate,
				EndingDueDate,
				StartingDueDateOffset,
				EndingDueDateOffset,
				StartingLastRcvdDate,
				EndingLastRcvdDate,
				StartingLastRcvdDateOffset,
				EndingLastRcvdDateOffset,
				StartingPO,
				EndingPO,
				StartingVendor,
				EndingVendor,
				StartingOrderDate,
				EndingOrderDate,
				StartingOrderDateOffset,
				EndingOrderDateOffset,
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
