//PROJECT NAME: ReportExt
//CLASS NAME: SLInboundPOAcknowledgmentReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Data.RecordSets;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLInboundPOAcknowledgmentReport")]
    public class SLInboundPOAcknowledgmentReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InboundPOAcknowledgmentSp([Optional] string StartVendor,
		                                               [Optional] string EndVendor,
		                                               [Optional] string StartPO,
		                                               [Optional] string EndPO,
		                                               [Optional] string StartVendorOrder,
		                                               [Optional] string EndVendorOrder,
		                                               [Optional] string Posted,
		                                               [Optional] byte? ShowDetail,
		                                               [Optional] byte? ShowErrorOnly,
		                                               [Optional] byte? ShowInternal,
		                                               [Optional] byte? ShowExternal,
		                                               [Optional] byte? PoAckNotes,
		                                               [Optional] byte? PoAckBlnNotes,
		                                               [Optional] byte? PoAckItemNotes,
		                                               [Optional] byte? DisplayHeader,
		                                               [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InboundPOAcknowledgmentExt = new Rpt_InboundPOAcknowledgmentFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InboundPOAcknowledgmentExt.Rpt_InboundPOAcknowledgmentSp(StartVendor,
				                                                                           EndVendor,
				                                                                           StartPO,
				                                                                           EndPO,
				                                                                           StartVendorOrder,
				                                                                           EndVendorOrder,
				                                                                           Posted,
				                                                                           ShowDetail,
				                                                                           ShowErrorOnly,
				                                                                           ShowInternal,
				                                                                           ShowExternal,
				                                                                           PoAckNotes,
				                                                                           PoAckBlnNotes,
				                                                                           PoAckItemNotes,
				                                                                           DisplayHeader,
				                                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
