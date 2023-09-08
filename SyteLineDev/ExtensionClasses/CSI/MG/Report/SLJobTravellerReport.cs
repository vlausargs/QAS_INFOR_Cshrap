//PROJECT NAME: ReportExt
//CLASS NAME: SLJobTravellerReport.cs

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
    [IDOExtensionClass("SLJobTravellerReport")]
    public class SLJobTravellerReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobTravellerSp([Optional] string StartJob,
		[Optional] string EndJob,
		[Optional] int? StartSuffix,
		[Optional] int? EndSuffix,
		[Optional] string JobStat,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] string StartProdMix,
		[Optional] string EndProdMix,
		[Optional] DateTime? StartJobDate,
		[Optional] DateTime? EndJobDate,
		[Optional] int? StartOpera,
		[Optional] int? EndOpera,
		[Optional] int? JobTravDate,
		[Optional] int? JobTravHr,
		[Optional] string JobTravBC,
		[Optional] int? PrintBCFmt,
		[Optional] int? PageOpera,
		[Optional] int? StartJobDateOffset,
		[Optional] int? EndJobDateOffset,
		[Optional] int? JobRouteShowInternal,
		[Optional] int? JobRouteShowExternal,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobTravellerExt = new Rpt_JobTravellerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobTravellerExt.Rpt_JobTravellerSp(StartJob,
				EndJob,
				StartSuffix,
				EndSuffix,
				JobStat,
				StartItem,
				EndItem,
				StartProdMix,
				EndProdMix,
				StartJobDate,
				EndJobDate,
				StartOpera,
				EndOpera,
				JobTravDate,
				JobTravHr,
				JobTravBC,
				PrintBCFmt,
				PageOpera,
				StartJobDateOffset,
				EndJobDateOffset,
				JobRouteShowInternal,
				JobRouteShowExternal,
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
