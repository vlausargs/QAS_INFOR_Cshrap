//PROJECT NAME: ReportExt
//CLASS NAME: SLEstimateJobIndentedBOMReport.cs

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
    [IDOExtensionClass("SLEstimateJobIndentedBOMReport")]
    public class SLEstimateJobIndentedBOMReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EstimateJobIndentedBOMSp([Optional] string JobStarting,
		                                              [Optional] string JobEnding,
		                                              [Optional] short? SuffixStarting,
		                                              [Optional] short? SuffixEnding,
		                                              [Optional] byte? PrintItemDesc,
		                                              [Optional] string PrintBetweenLevel,
		                                              [Optional] byte? PrintRefFields,
		                                              [Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EstimateJobIndentedBOMExt = new Rpt_EstimateJobIndentedBOMFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EstimateJobIndentedBOMExt.Rpt_EstimateJobIndentedBOMSp(JobStarting,
				                                                                         JobEnding,
				                                                                         SuffixStarting,
				                                                                         SuffixEnding,
				                                                                         PrintItemDesc,
				                                                                         PrintBetweenLevel,
				                                                                         PrintRefFields,
				                                                                         DisplayHeader,
				                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
