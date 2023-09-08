//PROJECT NAME: ReportExt
//CLASS NAME: SLPrintInventoryTags.cs

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
    [IDOExtensionClass("SLPrintInventoryTags")]
    public class SLPrintInventoryTags : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PrintInventoryTagsSp([Optional] string PSessionIDChar,
		[Optional] string Whse,
		[Optional] int? bPrintBlankTags,
		[Optional] int? bPrintBarcodeFormat,
		[Optional] int? bPrintZeroQty,
		[Optional] string sStartLoc,
		[Optional] string sEndLoc,
		[Optional] string sStartLot,
		[Optional] string sEndLot,
		[Optional] int? sStartTag,
		[Optional] int? sEndTag,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PrintInventoryTagsExt = new Rpt_PrintInventoryTagsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PrintInventoryTagsExt.Rpt_PrintInventoryTagsSp(PSessionIDChar,
				Whse,
				bPrintBlankTags,
				bPrintBarcodeFormat,
				bPrintZeroQty,
				sStartLoc,
				sEndLoc,
				sStartLot,
				sEndLot,
				sStartTag,
				sEndTag,
				DisplayHeader,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
