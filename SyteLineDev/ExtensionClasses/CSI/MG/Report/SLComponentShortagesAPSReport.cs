//PROJECT NAME: ReportExt
//CLASS NAME: SLComponentShortagesAPSReport.cs

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
    [IDOExtensionClass("SLComponentShortagesAPSReport")]
    public class SLComponentShortagesAPSReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ComponentShortagesApsSp(string PlannerCodeStarting,
		                                             string PlannerCodeEnding,
		                                             string ItemStarting,
		                                             string ItemEnding,
		                                             string DemandType,
		                                             string DemandRef,
		                                             DateTime? StartDate,
		                                             DateTime? EndDate,
		                                             byte? DisplayHeader,
		                                             short? ALTNO,
		                                             [Optional] string pSite,
		                                             [Optional] string BGSessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ComponentShortagesApsExt = new Rpt_ComponentShortagesApsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ComponentShortagesApsExt.Rpt_ComponentShortagesApsSp(PlannerCodeStarting,
				                                                                       PlannerCodeEnding,
				                                                                       ItemStarting,
				                                                                       ItemEnding,
				                                                                       DemandType,
				                                                                       DemandRef,
				                                                                       StartDate,
				                                                                       EndDate,
				                                                                       DisplayHeader,
				                                                                       ALTNO,
				                                                                       pSite,
				                                                                       BGSessionId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
