//PROJECT NAME: ReportExt
//CLASS NAME: SLPrintDeliveryOrderProFormaInvoiceReport.cs

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
    [IDOExtensionClass("SLPrintDeliveryOrderProFormaInvoiceReport")]
    public class SLPrintDeliveryOrderProFormaInvoiceReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PrintDeliveryOrderProFormaInvoiceSp([Optional] string DOStarting,
		[Optional] string DOEnding,
		[Optional] int? PrintBlankPickupDate,
		[Optional] int? PrintDOSeqText,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? CustSeqStarting,
		[Optional] int? CustSeqEnding,
		[Optional] DateTime? PickupDateStarting,
		[Optional] DateTime? PickupDateEnding,
		[Optional] int? PickupDateStartingOffset,
		[Optional] int? PickupDateEndingOffset,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? PrintItemOverview,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PrintDeliveryOrderProFormaInvoiceExt = new Rpt_PrintDeliveryOrderProFormaInvoiceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PrintDeliveryOrderProFormaInvoiceExt.Rpt_PrintDeliveryOrderProFormaInvoiceSp(DOStarting,
				DOEnding,
				PrintBlankPickupDate,
				PrintDOSeqText,
				CustomerStarting,
				CustomerEnding,
				CustSeqStarting,
				CustSeqEnding,
				PickupDateStarting,
				PickupDateEnding,
				PickupDateStartingOffset,
				PickupDateEndingOffset,
				ShowInternal,
				ShowExternal,
				PrintItemOverview,
				DisplayHeader,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
