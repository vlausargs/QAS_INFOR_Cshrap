//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerOrderKitPickListReport.cs

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
    [IDOExtensionClass("SLCustomerOrderKitPickListReport")]
    public class SLCustomerOrderKitPickListReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CustomerOrderKitPickListSP([Optional] string StartingCoNum,
		                                                [Optional] string EndingCoNum,
		                                                [Optional] int? StartingLineNum,
		                                                [Optional] int? EndingLineNum,
		                                                [Optional] int? StartingRelNum,
		                                                [Optional] int? EndingRelNum,
		                                                [Optional] string StartingKit,
		                                                [Optional] string EndingKit,
		                                                [Optional] decimal? StartingPickListId,
		                                                [Optional] decimal? EndingPickListId,
		                                                [Optional] byte? ProcessPickList,
		                                                [Optional] byte? SortByLoc,
		                                                [Optional] byte? PrintSecondaryLocations,
		                                                [Optional] byte? ExtendByScrapFactor,
		                                                [Optional] byte? PrintBarCode,
		                                                [Optional] byte? DisplayHeader,
		                                                [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CustomerOrderKitPickListExt = new Rpt_CustomerOrderKitPickListFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CustomerOrderKitPickListExt.Rpt_CustomerOrderKitPickListSP(StartingCoNum,
				                                                                             EndingCoNum,
				                                                                             StartingLineNum,
				                                                                             EndingLineNum,
				                                                                             StartingRelNum,
				                                                                             EndingRelNum,
				                                                                             StartingKit,
				                                                                             EndingKit,
				                                                                             StartingPickListId,
				                                                                             EndingPickListId,
				                                                                             ProcessPickList,
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
