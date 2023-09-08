//PROJECT NAME: ReportExt
//CLASS NAME: SLPrintInventorySheetsReport.cs

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
    [IDOExtensionClass("SLPrintInventorySheetsReport")]
    public class SLPrintInventorySheetsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PrintInventorySheetsSp([Optional] string PSessionIDChar,
		[Optional] string Whse,
		[Optional] int? bPrintBlankSheets,
		[Optional] int? bPrintBarcodeFormat,
		[Optional] int? bPrintZeroQty,
		[Optional] string sStartLoc,
		[Optional] string sEndLoc,
		[Optional] string sStartLot,
		[Optional] string sEndLot,
		[Optional] int? sStartSheet,
		[Optional] int? sEndSheet,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue(0)] int? PrintPieces,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PrintInventorySheetsExt = new Rpt_PrintInventorySheetsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PrintInventorySheetsExt.Rpt_PrintInventorySheetsSp(PSessionIDChar,
				Whse,
				bPrintBlankSheets,
				bPrintBarcodeFormat,
				bPrintZeroQty,
				sStartLoc,
				sEndLoc,
				sStartLot,
				sEndLot,
				sStartSheet,
				sEndSheet,
				DisplayHeader,
				PrintPieces,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
