//PROJECT NAME: ReportExt
//CLASS NAME: SLTransferOrderKitPickListReport.cs

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
    [IDOExtensionClass("SLTransferOrderKitPickListReport")]
    public class SLTransferOrderKitPickListReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TransferOrderKitPickListSP([Optional] string StartingTrnNum,
		[Optional] string EndingTrnNum,
		[Optional] int? StartingLineNum,
		[Optional] int? EndingLineNum,
		[Optional] string StartingKit,
		[Optional] string EndingKit,
		[Optional] int? SortByLoc,
		[Optional] int? PrintSecondaryLocations,
		[Optional] int? ExtendByScrapFactor,
		[Optional] int? PrintBarCode,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TransferOrderKitPickListExt = new Rpt_TransferOrderKitPickListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TransferOrderKitPickListExt.Rpt_TransferOrderKitPickListSP(StartingTrnNum,
				EndingTrnNum,
				StartingLineNum,
				EndingLineNum,
				StartingKit,
				EndingKit,
				SortByLoc,
				PrintSecondaryLocations,
				ExtendByScrapFactor,
				PrintBarCode,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
