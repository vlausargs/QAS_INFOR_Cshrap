//PROJECT NAME: ReportExt
//CLASS NAME: SLJobMaterialKitPickListReport.cs

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
    [IDOExtensionClass("SLJobMaterialKitPickListReport")]
    public class SLJobMaterialKitPickListReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobMaterialKitPickListSP([Optional] string StartingJob,
		[Optional] int? StartingSuffix,
		[Optional] string EndingJob,
		[Optional] int? EndingSuffix,
		[Optional] int? StartingOperNum,
		[Optional] int? EndingOperNum,
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
				
				var iRpt_JobMaterialKitPickListExt = new Rpt_JobMaterialKitPickListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobMaterialKitPickListExt.Rpt_JobMaterialKitPickListSP(StartingJob,
				StartingSuffix,
				EndingJob,
				EndingSuffix,
				StartingOperNum,
				EndingOperNum,
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
