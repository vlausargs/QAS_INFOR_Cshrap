//PROJECT NAME: ReportExt
//CLASS NAME: SLShipmentPackingSlipReport.cs

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
    [IDOExtensionClass("SLShipmentPackingSlipReport")]
    public class SLShipmentPackingSlipReport : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ShipmentPackingSlipSp([Optional] int? PrintBlankPickupDate,
		[Optional] int? IncludeSerialNumbers,
		[Optional] int? PrintShipmentSequenceText,
		[Optional] int? DisplayShipmentSeqNotes,
		[Optional] int? DisplayShipmentPackageNotes,
		[Optional] decimal? MinShipNum,
		[Optional] decimal? MaxShipNum,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? ShiptoStarting,
		[Optional] int? ShiptoEnding,
		[Optional] DateTime? PickupDateStarting,
		[Optional] DateTime? PickupDateEnding,
		[Optional] int? DateStartingOffset,
		[Optional] int? DateEndingOffset,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] int? PrintDescription,
		[Optional] int? pPrintHeaderOnAllPages,
		[Optional] int? pPageBetweenPackages,
		[Optional] int? pPrintCertificateOfConformance,
		[Optional] int? pPrintPackageWeight,
		[Optional] int? pPrintDeliveryIncoTerms,
		[Optional] int? pPrintEUDetails,
		[Optional] int? pPrintKitComponents,
		[Optional] int? pPrintLotNumbers)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ShipmentPackingSlipExt = new Rpt_ShipmentPackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ShipmentPackingSlipExt.Rpt_ShipmentPackingSlipSp(PrintBlankPickupDate,
				IncludeSerialNumbers,
				PrintShipmentSequenceText,
				DisplayShipmentSeqNotes,
				DisplayShipmentPackageNotes,
				MinShipNum,
				MaxShipNum,
				CustomerStarting,
				CustomerEnding,
				ShiptoStarting,
				ShiptoEnding,
				PickupDateStarting,
				PickupDateEnding,
				DateStartingOffset,
				DateEndingOffset,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				pSite,
				PrintDescription,
				pPrintHeaderOnAllPages,
				pPageBetweenPackages,
				pPrintCertificateOfConformance,
				pPrintPackageWeight,
				pPrintDeliveryIncoTerms,
				pPrintEUDetails,
				pPrintKitComponents,
				pPrintLotNumbers);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
