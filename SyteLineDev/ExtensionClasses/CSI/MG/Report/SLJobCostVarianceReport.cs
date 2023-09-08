//PROJECT NAME: ReportExt
//CLASS NAME: SLJobCostVarianceReport.cs

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
    [IDOExtensionClass("SLJobCostVarianceReport")]
    public class SLJobCostVarianceReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobCostVarianceSp([Optional] string StartJob,
		[Optional] string EndJob,
		[Optional] int? SSuffix,
		[Optional] int? ESuffix,
		[Optional] string Status,
		[Optional] string VarianceType,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] string SCustNum,
		[Optional] string ECustNum,
		[Optional] string SProdMix,
		[Optional] string EProdMix,
		[Optional] string OrdType,
		[Optional] string SOrdNum,
		[Optional] string EOrdNum,
		[Optional] DateTime? SLstTrxDate,
		[Optional] DateTime? ELstTrxDate,
		[Optional] DateTime? StartJobDate,
		[Optional] DateTime? EndJobDate,
		[Optional] int? SLstTrxDateOffset,
		[Optional] int? ELstTrxDateOffset,
		[Optional] int? SJobDateOffset,
		[Optional] int? EJobDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] Guid? ProcessId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobCostVarianceExt = new Rpt_JobCostVarianceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobCostVarianceExt.Rpt_JobCostVarianceSp(StartJob,
				EndJob,
				SSuffix,
				ESuffix,
				Status,
				VarianceType,
				StartItem,
				EndItem,
				SCustNum,
				ECustNum,
				SProdMix,
				EProdMix,
				OrdType,
				SOrdNum,
				EOrdNum,
				SLstTrxDate,
				ELstTrxDate,
				StartJobDate,
				EndJobDate,
				SLstTrxDateOffset,
				ELstTrxDateOffset,
				SJobDateOffset,
				EJobDateOffset,
				DisplayHeader,
				pSite,
				ProcessId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
