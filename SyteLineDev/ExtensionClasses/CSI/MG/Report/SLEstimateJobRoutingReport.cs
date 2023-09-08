//PROJECT NAME: ReportExt
//CLASS NAME: SLEstimateJobRoutingReport.cs

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
    [IDOExtensionClass("SLEstimateJobRoutingReport")]
    public class SLEstimateJobRoutingReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EstimateJobRoutingSp([Optional] string JobStarting,
		                                          [Optional] string JobEnding,
		                                          [Optional] short? SuffixStarting,
		                                          [Optional] short? SuffixEnding,
		                                          [Optional] string OperStarting,
		                                          [Optional] string OperEnding,
		                                          [Optional] byte? Pageoper,
		                                          [Optional] byte? Reffields,
		                                          [Optional] string Prcfgdetail,
		                                          [Optional, DefaultParameterValue((byte)1)] byte? ShowInternal,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowExternal,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintNoteJobRoute,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintNoteJobmatl,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EstimateJobRoutingExt = new Rpt_EstimateJobRoutingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EstimateJobRoutingExt.Rpt_EstimateJobRoutingSp(JobStarting,
				                                                                 JobEnding,
				                                                                 SuffixStarting,
				                                                                 SuffixEnding,
				                                                                 OperStarting,
				                                                                 OperEnding,
				                                                                 Pageoper,
				                                                                 Reffields,
				                                                                 Prcfgdetail,
				                                                                 ShowInternal,
				                                                                 ShowExternal,
				                                                                 PrintNoteJobRoute,
				                                                                 PrintNoteJobmatl,
				                                                                 DisplayHeader,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
