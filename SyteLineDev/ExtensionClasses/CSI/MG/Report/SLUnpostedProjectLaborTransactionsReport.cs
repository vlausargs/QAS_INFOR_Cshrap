//PROJECT NAME: ReportExt
//CLASS NAME: SLUnpostedProjectLaborTransactionsReport.cs

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
	[IDOExtensionClass("SLUnpostedProjectLaborTransactionsReport")]
	public class SLUnpostedProjectLaborTransactionsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_UnpostedProjectLaborTransactionSp([Optional] string ProjectStarting,
		[Optional] string ProjectEnding,
		[Optional] int? TaskStarting,
		[Optional] int? TaskEnding,
		[Optional] DateTime? TransactionDateStarting,
		[Optional] DateTime? TransactionDateEnding,
		[Optional] string EmployeeStarting,
		[Optional] string EmployeeEnding,
		[Optional] int? DateStartingOffSET,
		[Optional] int? DateEndingOffSET,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] int? DisplayHeader,
		Guid? PSessionID,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_UnpostedProjectLaborTransactionExt = new Rpt_UnpostedProjectLaborTransactionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_UnpostedProjectLaborTransactionExt.Rpt_UnpostedProjectLaborTransactionSp(ProjectStarting,
				ProjectEnding,
				TaskStarting,
				TaskEnding,
				TransactionDateStarting,
				TransactionDateEnding,
				EmployeeStarting,
				EmployeeEnding,
				DateStartingOffSET,
				DateEndingOffSET,
				PrintCost,
				DisplayHeader,
				PSessionID,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
