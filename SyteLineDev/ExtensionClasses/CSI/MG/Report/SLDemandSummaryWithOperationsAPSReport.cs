//PROJECT NAME: ReportExt
//CLASS NAME: SLDemandSummaryWithOperationsAPSReport.cs

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
    [IDOExtensionClass("SLDemandSummaryWithOperationsAPSReport")]
    public class SLDemandSummaryWithOperationsAPSReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DemandSummaryWithOperationsAPSSp([Optional] string ItemStarting,
		                                                      [Optional] string ItemEnding,
		                                                      [Optional] DateTime? StartDate,
		                                                      [Optional] DateTime? EndDate,
		                                                      [Optional, DefaultParameterValue((short)0)] short? AltNum,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_DemandSummaryWithOperationsAPSExt = new Rpt_DemandSummaryWithOperationsAPSFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_DemandSummaryWithOperationsAPSExt.Rpt_DemandSummaryWithOperationsAPSSp(ItemStarting,
				                                                                                         ItemEnding,
				                                                                                         StartDate,
				                                                                                         EndDate,
				                                                                                         AltNum,
				                                                                                         DisplayHeader,
				                                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
