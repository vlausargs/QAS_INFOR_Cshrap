//PROJECT NAME: ReportExt
//CLASS NAME: SLPrintDeliveryOrderProFormaInvoiceSerReport.cs

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
    [IDOExtensionClass("SLPrintDeliveryOrderProFormaInvoiceSerReport")]
    public class SLPrintDeliveryOrderProFormaInvoiceSerReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PrintDeliveryOrderProFormaInvoiceSerSp(string DoNum,
		int? DoLine,
		int? DoSeq,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PrintDeliveryOrderProFormaInvoiceSerExt = new Rpt_PrintDeliveryOrderProFormaInvoiceSerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PrintDeliveryOrderProFormaInvoiceSerExt.Rpt_PrintDeliveryOrderProFormaInvoiceSerSp(DoNum,
				DoLine,
				DoSeq,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
