//PROJECT NAME: ReportExt
//CLASS NAME: SLShipmentBillofLadingReport.cs

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
    [IDOExtensionClass("SLShipmentBillofLadingReport")]
    public class SLShipmentBillofLadingReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ShipmentBillofLadingSp([Optional] decimal? ShipmentStarting,
		[Optional] decimal? ShipmentEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? CustSeqStarting,
		[Optional] int? CustSeqEnding,
		[Optional] DateTime? PickupDateStarting,
		[Optional] DateTime? PickupDateEnding,
		[Optional] int? PickupDateStartingOffset,
		[Optional] int? PickupDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ShipmentBillofLadingExt = new Rpt_ShipmentBillofLadingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ShipmentBillofLadingExt.Rpt_ShipmentBillofLadingSp(ShipmentStarting,
				ShipmentEnding,
				CustomerStarting,
				CustomerEnding,
				CustSeqStarting,
				CustSeqEnding,
				PickupDateStarting,
				PickupDateEnding,
				PickupDateStartingOffset,
				PickupDateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
