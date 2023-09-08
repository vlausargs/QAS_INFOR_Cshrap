//PROJECT NAME: ReportExt
//CLASS NAME: SLPrintDeliveryOrderPackingSlipReport.cs

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
	[IDOExtensionClass("SLPrintDeliveryOrderPackingSlipReport")]
	public class SLPrintDeliveryOrderPackingSlipReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PrintDeliveryOrderPackingSlipSp([Optional] string StartingDo,
		[Optional] string EndingDo,
		[Optional] int? PrPickupDate,
		[Optional] int? PrDoSeqText,
		[Optional] int? PrDoLineText,
		[Optional] int? PrDoText,
		[Optional] int? PageByDoLine,
		[Optional] int? PrSerialNumbers,
		[Optional] string StatingCust,
		[Optional] string EndingCust,
		[Optional] int? StatingShipTo,
		[Optional] int? EndingShipTo,
		[Optional] DateTime? StatingPickupDate,
		[Optional] DateTime? EndingPickupDate,
		[Optional] int? StatingPickupDateOffset,
		[Optional] int? EndingPickupDateOffset,
		[Optional, DefaultParameterValue(1)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional] int? PrintItemOverview,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PrintDeliveryOrderPackingSlipExt = new Rpt_PrintDeliveryOrderPackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PrintDeliveryOrderPackingSlipExt.Rpt_PrintDeliveryOrderPackingSlipSp(StartingDo,
				EndingDo,
				PrPickupDate,
				PrDoSeqText,
				PrDoLineText,
				PrDoText,
				PageByDoLine,
				PrSerialNumbers,
				StatingCust,
				EndingCust,
				StatingShipTo,
				EndingShipTo,
				StatingPickupDate,
				EndingPickupDate,
				StatingPickupDateOffset,
				EndingPickupDateOffset,
				ShowInternal,
				ShowExternal,
				PrintItemOverview,
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
