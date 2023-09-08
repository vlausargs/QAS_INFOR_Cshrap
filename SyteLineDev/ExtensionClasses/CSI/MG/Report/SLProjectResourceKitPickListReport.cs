//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectResourceKitPickListReport.cs

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
    [IDOExtensionClass("SLProjectResourceKitPickListReport")]
    public class SLProjectResourceKitPickListReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectResourceKitPickListSp([Optional] string StartingProjNum,
		[Optional] string EndingProjNum,
		[Optional] int? StartingTaskNum,
		[Optional] int? EndingTaskNum,
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
				
				var iRpt_ProjectResourceKitPickListExt = new Rpt_ProjectResourceKitPickListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectResourceKitPickListExt.Rpt_ProjectResourceKitPickListSp(StartingProjNum,
				EndingProjNum,
				StartingTaskNum,
				EndingTaskNum,
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
