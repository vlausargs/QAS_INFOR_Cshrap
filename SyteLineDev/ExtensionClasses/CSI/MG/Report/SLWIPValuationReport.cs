//PROJECT NAME: ReportExt
//CLASS NAME: SLWIPValuationReport.cs

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
    [IDOExtensionClass("SLWIPValuationReport")]
    public class SLWIPValuationReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_WipValuationSp([Optional] string PStartingProdCode,
		[Optional] string PEndingProdCode,
		[Optional] string PStartingItem,
		[Optional] string PEndingItem,
		[Optional] string PStartingJob,
		[Optional] string PEndingJob,
		[Optional] int? PStartingSubJob,
		[Optional] int? PEndingSubJob,
		[Optional, DefaultParameterValue("RSC")] string PJobStatus,
		[Optional, DefaultParameterValue(0)] int? PShowDetail,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_WipValuationExt = new Rpt_WipValuationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_WipValuationExt.Rpt_WipValuationSp(PStartingProdCode,
				PEndingProdCode,
				PStartingItem,
				PEndingItem,
				PStartingJob,
				PEndingJob,
				PStartingSubJob,
				PEndingSubJob,
				PJobStatus,
				PShowDetail,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
