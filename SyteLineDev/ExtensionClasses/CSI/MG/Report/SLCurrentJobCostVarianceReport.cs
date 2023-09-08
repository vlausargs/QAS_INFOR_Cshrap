//PROJECT NAME: ReportExt
//CLASS NAME: SLCurrentJobCostVarianceReport.cs

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
    [IDOExtensionClass("SLCurrentJobCostVarianceReport")]
    public class SLCurrentJobCostVarianceReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CurrentJobCostVarianceSp([Optional] string JobStarting,
		                                              [Optional] short? JobStartSuffix,
		                                              [Optional] string JobEnding,
		                                              [Optional] short? JobEndSuffix,
		                                              [Optional] string ExOptgoJJobStat,
		                                              [Optional] string ItemStarting,
		                                              [Optional] string ItemEnding,
		                                              [Optional] string CustStarting,
		                                              [Optional] string CustEnding,
		                                              [Optional] string CoProdMixStarting,
		                                              [Optional] string CoProdMixEnding,
		                                              [Optional] string ExOptgoOrdType,
		                                              [Optional] string OrdNumStarting,
		                                              [Optional] string OrdNumEnding,
		                                              [Optional] DateTime? LstTrxDateStarting,
		                                              [Optional] DateTime? LstTrxDateEnding,
		                                              [Optional] DateTime? JobDateStarting,
		                                              [Optional] DateTime? JobDateEnding,
		                                              [Optional] short? LstTrxDateStartingOffset,
		                                              [Optional] short? LstTrxDateEndingOffset,
		                                              [Optional] short? JobDateStartingOffset,
		                                              [Optional] short? JobDateEndingOffset,
		                                              [Optional] byte? DisplayHeader,
		                                              [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CurrentJobCostVarianceExt = new Rpt_CurrentJobCostVarianceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CurrentJobCostVarianceExt.Rpt_CurrentJobCostVarianceSp(JobStarting,
				                                                                         JobStartSuffix,
				                                                                         JobEnding,
				                                                                         JobEndSuffix,
				                                                                         ExOptgoJJobStat,
				                                                                         ItemStarting,
				                                                                         ItemEnding,
				                                                                         CustStarting,
				                                                                         CustEnding,
				                                                                         CoProdMixStarting,
				                                                                         CoProdMixEnding,
				                                                                         ExOptgoOrdType,
				                                                                         OrdNumStarting,
				                                                                         OrdNumEnding,
				                                                                         LstTrxDateStarting,
				                                                                         LstTrxDateEnding,
				                                                                         JobDateStarting,
				                                                                         JobDateEnding,
				                                                                         LstTrxDateStartingOffset,
				                                                                         LstTrxDateEndingOffset,
				                                                                         JobDateStartingOffset,
				                                                                         JobDateEndingOffset,
				                                                                         DisplayHeader,
				                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
