//PROJECT NAME: ReportExt
//CLASS NAME: SLGoodsReceivingNoteReport.cs

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
    [IDOExtensionClass("SLGoodsReceivingNoteReport")]
    public class SLGoodsReceivingNoteReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable rpt_goodsreceivingnotesp([Optional] string GRNStatus,
		                                          [Optional, DefaultParameterValue((byte)0)] byte? PageBreakByGRN,
		[Optional] string StartingGRN,
		[Optional] string EndingGRN,
		[Optional] string StartingVendor,
		[Optional] string EndingVendor,
		[Optional] byte? ShowInternal,
		[Optional] byte? ShowExternal,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string pSite,
		[Optional] byte? PrintItemOverview)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var irpt_goodsreceivingnoteExt = new rpt_goodsreceivingnoteFactory().Create(appDb, bunchedLoadCollection);
				
				var result = irpt_goodsreceivingnoteExt.rpt_goodsreceivingnotesp(GRNStatus,
				                                                                 PageBreakByGRN,
				                                                                 StartingGRN,
				                                                                 EndingGRN,
				                                                                 StartingVendor,
				                                                                 EndingVendor,
				                                                                 ShowInternal,
				                                                                 ShowExternal,
				                                                                 DisplayHeader,
				                                                                 pSite,
				                                                                 PrintItemOverview);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
