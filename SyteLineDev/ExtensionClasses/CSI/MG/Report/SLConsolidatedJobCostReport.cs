//PROJECT NAME: ReportExt
//CLASS NAME: SLConsolidatedJobCostReport.cs

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
    [IDOExtensionClass("SLConsolidatedJobCostReport")]
    public class SLConsolidatedJobCostReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ConsolidatedJobCostSp([Optional] string PrimeJob,
		                                           [Optional] short? JobSuffixStarting,
		                                           [Optional] short? JobSuffixEnding,
		                                           [Optional] byte? DisplayHeader,
		                                           [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ConsolidatedJobCostExt = new Rpt_ConsolidatedJobCostFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ConsolidatedJobCostExt.Rpt_ConsolidatedJobCostSp(PrimeJob,
				                                                                   JobSuffixStarting,
				                                                                   JobSuffixEnding,
				                                                                   DisplayHeader,
				                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
