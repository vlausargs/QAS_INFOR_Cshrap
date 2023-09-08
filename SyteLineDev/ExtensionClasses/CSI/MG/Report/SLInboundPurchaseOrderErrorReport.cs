//PROJECT NAME: ReportExt
//CLASS NAME: SLInboundPurchaseOrderErrorReport.cs

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
    [IDOExtensionClass("SLInboundPurchaseOrderErrorReport")]
    public class SLInboundPurchaseOrderErrorReport : ExtensionClassBase
    {
    

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InboundPurchaseOrderErrorSp([Optional] string CustomerStarting,
		                                                 [Optional] string CustomerEnding,
		                                                 [Optional] DateTime? RecDateStarting,
		                                                 [Optional] DateTime? RecDateEnding,
		                                                 [Optional] short? RecDateStartingOffset,
		                                                 [Optional] short? RecDateEndingOffset,
		                                                 [Optional] byte? DisplayHeader,
		                                                 [Optional] int? TaskId,
		                                                 [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InboundPurchaseOrderErrorExt = new Rpt_InboundPurchaseOrderErrorFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InboundPurchaseOrderErrorExt.Rpt_InboundPurchaseOrderErrorSp(CustomerStarting,
				                                                                               CustomerEnding,
				                                                                               RecDateStarting,
				                                                                               RecDateEnding,
				                                                                               RecDateStartingOffset,
				                                                                               RecDateEndingOffset,
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
