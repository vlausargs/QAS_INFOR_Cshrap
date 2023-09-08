//PROJECT NAME: ReportExt
//CLASS NAME: SLJobCostDetailBreakoutReport.cs

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
    [IDOExtensionClass("SLJobCostDetailBreakoutReport")]
    public class SLJobCostDetailBreakoutReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobCostDetailBreakoutSp([Optional] string JobStarting,
		[Optional] int? JobStartSuffix,
		[Optional] string JobEnding,
		[Optional] int? JobEndSuffix,
		[Optional] string ExOptgoJJobStat,
		[Optional] string ExOptacCostComponent,
		[Optional] string CustStarting,
		[Optional] string CustEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string ExOptgoOrdType,
		[Optional] string OrdNumStarting,
		[Optional] string OrdNumEnding,
		[Optional] DateTime? LstTrxDateStarting,
		[Optional] DateTime? LstTrxDateEnding,
		[Optional] DateTime? JobDateStarting,
		[Optional] DateTime? JobDateEnding,
		[Optional] int? LstTrxDateStartingOffset,
		[Optional] int? LstTrxDateEndingOffset,
		[Optional] int? JobDateStartingOffset,
		[Optional] int? JobDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobCostDetailBreakoutExt = new Rpt_JobCostDetailBreakoutFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobCostDetailBreakoutExt.Rpt_JobCostDetailBreakoutSp(JobStarting,
				JobStartSuffix,
				JobEnding,
				JobEndSuffix,
				ExOptgoJJobStat,
				ExOptacCostComponent,
				CustStarting,
				CustEnding,
				ItemStarting,
				ItemEnding,
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
