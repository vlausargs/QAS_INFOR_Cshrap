//PROJECT NAME: ReportExt
//CLASS NAME: SLInboundVendorShipNoticeReport.cs

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
    [IDOExtensionClass("SLInboundVendorShipNoticeReport")]
    public class SLInboundVendorShipNoticeReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InboundVendorShipNoticeSp([Optional] string StartVendor,
		                                               [Optional] string EndVendor,
		                                               [Optional] string StartGrn,
		                                               [Optional] string EndGrn,
		                                               [Optional] DateTime? StartOrderDate,
		                                               [Optional] DateTime? EndOrderDate,
		                                               [Optional] string StartVendorOrder,
		                                               [Optional] string EndVendorOrder,
		                                               [Optional] string StartItem,
		                                               [Optional] string EndItem,
		                                               [Optional] byte? ShowDetail,
		                                               [Optional] byte? ShowErrorOnly,
		                                               [Optional] short? StartOrderDateOffset,
		                                               [Optional] short? EndOrderDateOffset,
		                                               [Optional] byte? DisplayHeader,
		                                               [Optional] byte? IncludeSerialNumbers,
		                                               [Optional] string pSite,
		                                               [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InboundVendorShipNoticeExt = new Rpt_InboundVendorShipNoticeFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InboundVendorShipNoticeExt.Rpt_InboundVendorShipNoticeSp(StartVendor,
				                                                                           EndVendor,
				                                                                           StartGrn,
				                                                                           EndGrn,
				                                                                           StartOrderDate,
				                                                                           EndOrderDate,
				                                                                           StartVendorOrder,
				                                                                           EndVendorOrder,
				                                                                           StartItem,
				                                                                           EndItem,
				                                                                           ShowDetail,
				                                                                           ShowErrorOnly,
				                                                                           StartOrderDateOffset,
				                                                                           EndOrderDateOffset,
				                                                                           DisplayHeader,
				                                                                           IncludeSerialNumbers,
				                                                                           pSite,
				                                                                           BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
