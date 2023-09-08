//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionScheduleTransactionReport.cs

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
    [IDOExtensionClass("SLProductionScheduleTransactionReport")]
    public class SLProductionScheduleTransactionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductionScheduleTransactionSp([Optional] string PSNumStarting,
		[Optional] string PSNumEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string WcStarting,
		[Optional] string WcEnding,
		[Optional] string ShiftStarting,
		[Optional] string ShiftEnding,
		[Optional] DateTime? TransDateStarting,
		[Optional] DateTime? TransDateEnding,
		[Optional] int? TransDateStartingOffset,
		[Optional] int? TransDateEndingOffset,
		[Optional] string BackFlushTrans,
		[Optional] int? CompleteStatusReport,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string DocumentNumStarting,
		[Optional] string DocumentNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductionScheduleTransactionExt = new Rpt_ProductionScheduleTransactionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductionScheduleTransactionExt.Rpt_ProductionScheduleTransactionSp(PSNumStarting,
				PSNumEnding,
				ItemStarting,
				ItemEnding,
				WcStarting,
				WcEnding,
				ShiftStarting,
				ShiftEnding,
				TransDateStarting,
				TransDateEnding,
				TransDateStartingOffset,
				TransDateEndingOffset,
				BackFlushTrans,
				CompleteStatusReport,
				DisplayHeader,
				pSite,
				DocumentNumStarting,
				DocumentNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
