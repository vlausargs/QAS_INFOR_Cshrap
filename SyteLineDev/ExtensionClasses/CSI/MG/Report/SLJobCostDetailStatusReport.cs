//PROJECT NAME: ReportExt
//CLASS NAME: SLJobCostDetailStatusReport.cs

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
    [IDOExtensionClass("SLJobCostDetailStatusReport")]
    public class SLJobCostDetailStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobCostDetailStatusSp([Optional] string PStartingJob,
		[Optional] string PEndingJob,
		[Optional] int? PStartingSubJob,
		[Optional] int? PEndingSubJob,
		[Optional] string PJobStatus,
		[Optional] string PCostComponent,
		[Optional] string PStartingCustomer,
		[Optional] string PEndingCustomer,
		[Optional] string PStartingItem,
		[Optional] string PEndingItem,
		[Optional] string PStartingProdMix,
		[Optional] string PEndingProdMix,
		[Optional] string POrderType,
		[Optional] string PStartingOrderNum,
		[Optional] string PEndingOrderNum,
		[Optional] DateTime? PStartingTrxDate,
		[Optional] DateTime? PEndingTrxDate,
		[Optional] DateTime? PStartingJobDate,
		[Optional] DateTime? PEndingJobDate,
		[Optional] int? PStartingTrxDateOffset,
		[Optional] int? PEndingTrxDateOffset,
		[Optional] int? PStartingJobDateOffset,
		[Optional] int? PEndingJobDateOffset,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobCostDetailStatusExt = new Rpt_JobCostDetailStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobCostDetailStatusExt.Rpt_JobCostDetailStatusSp(PStartingJob,
				PEndingJob,
				PStartingSubJob,
				PEndingSubJob,
				PJobStatus,
				PCostComponent,
				PStartingCustomer,
				PEndingCustomer,
				PStartingItem,
				PEndingItem,
				PStartingProdMix,
				PEndingProdMix,
				POrderType,
				PStartingOrderNum,
				PEndingOrderNum,
				PStartingTrxDate,
				PEndingTrxDate,
				PStartingJobDate,
				PEndingJobDate,
				PStartingTrxDateOffset,
				PEndingTrxDateOffset,
				PStartingJobDateOffset,
				PEndingJobDateOffset,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
