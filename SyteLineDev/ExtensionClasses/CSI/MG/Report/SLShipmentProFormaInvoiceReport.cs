//PROJECT NAME: ReportExt
//CLASS NAME: SLShipmentProFormaInvoiceReport.cs

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
    [IDOExtensionClass("SLShipmentProFormaInvoiceReport")]
    public class SLShipmentProFormaInvoiceReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ShipmentProFormaInvoiceSp([Optional] int? PrintBlankPickupDate,
		[Optional] int? PrintShipmentSequenceText,
		[Optional] int? IncludeSerialNumbers,
		[Optional] decimal? ShipmentStarting,
		[Optional] decimal? ShipmentEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? ShipToStarting,
		[Optional] int? ShipToEnding,
		[Optional] DateTime? PickupDateStarting,
		[Optional] DateTime? PickupDateEnding,
		[Optional] int? DateStartingOffset,
		[Optional] int? DateENDingOffset,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ShipmentProFormaInvoiceExt = new Rpt_ShipmentProFormaInvoiceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ShipmentProFormaInvoiceExt.Rpt_ShipmentProFormaInvoiceSp(PrintBlankPickupDate,
				PrintShipmentSequenceText,
				IncludeSerialNumbers,
				ShipmentStarting,
				ShipmentEnding,
				CustomerStarting,
				CustomerEnding,
				ShipToStarting,
				ShipToEnding,
				PickupDateStarting,
				PickupDateEnding,
				DateStartingOffset,
				DateENDingOffset,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
