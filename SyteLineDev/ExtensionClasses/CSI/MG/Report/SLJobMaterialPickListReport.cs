//PROJECT NAME: ReportExt
//CLASS NAME: SLJobMaterialPickListReport.cs

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
    [IDOExtensionClass("SLJobMaterialPickListReport")]
    public class SLJobMaterialPickListReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobMaterialPickListSp([Optional] string StartJob,
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
		[Optional] int? MatlLst132,
		[Optional] int? MatlLstDate,
		[Optional] int? PickByLoc,
		[Optional] int? PrintSN,
		[Optional] int? PrintBCFmt,
		[Optional] int? PageOpera,
		[Optional] int? PrintSecLoc,
		[Optional] int? ExtScrapFact,
		[Optional] string ReprintPick,
		[Optional] int? DisplayRefFields,
		[Optional] int? StartJobDateOffset,
		[Optional] int? EndJobDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobMaterialPickListExt = new Rpt_JobMaterialPickListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobMaterialPickListExt.Rpt_JobMaterialPickListSp(StartJob,
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
				MatlLst132,
				MatlLstDate,
				PickByLoc,
				PrintSN,
				PrintBCFmt,
				PageOpera,
				PrintSecLoc,
				ExtScrapFact,
				ReprintPick,
				DisplayRefFields,
				StartJobDateOffset,
				EndJobDateOffset,
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
