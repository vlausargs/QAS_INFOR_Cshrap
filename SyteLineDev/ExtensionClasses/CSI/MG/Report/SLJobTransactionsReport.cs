//PROJECT NAME: MG
//CLASS NAME: SLJobTransactionsReport.cs

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
	[IDOExtensionClass("SLJobTransactionsReport")]
	public class SLJobTransactionsReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobTransactionsSp([Optional] string TransactionType,
		[Optional] string PayType,
		[Optional] string Posted,
		[Optional] string EmployeeType,
		[Optional] int? ShowDetail,
		[Optional] string BackflushTransaction,
		[Optional] string EmployeeStarting,
		[Optional] string EmployeeEnding,
		[Optional] string JobStarting,
		[Optional] string JobEnding,
		[Optional] int? SuffixStarting,
		[Optional] int? SuffixEnding,
		[Optional] DateTime? TransactionDateStarting,
		[Optional] DateTime? TransactionDateEnding,
		[Optional] decimal? TransactionNumberStarting,
		[Optional] decimal? TransactionNumberEnding,
		[Optional] string ShiftStarting,
		[Optional] string ShiftEnding,
		[Optional] string ReasonStarting,
		[Optional] string ReasonEnding,
		[Optional] string UserInitialStarting,
		[Optional] string UserInitialEnding,
		[Optional] string ResourceStarting,
		[Optional] string ResourceEnding,
		[Optional] string SortByTEJ,
		[Optional] int? TransactionDateStartingOffset,
		[Optional] int? TransactionDateEndingOffset,
		[Optional] int? ViewCost,
		[Optional] int? DisplayHeader,
		[Optional] string PMessageLanguage,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			var iRpt_JobTransactionsExt = new Rpt_JobTransactionsFactory().Create(this, true);

			var result = iRpt_JobTransactionsExt.Rpt_JobTransactionsSp(TransactionType,
			PayType,
			Posted,
			EmployeeType,
			ShowDetail,
			BackflushTransaction,
			EmployeeStarting,
			EmployeeEnding,
			JobStarting,
			JobEnding,
			SuffixStarting,
			SuffixEnding,
			TransactionDateStarting,
			TransactionDateEnding,
			TransactionNumberStarting,
			TransactionNumberEnding,
			ShiftStarting,
			ShiftEnding,
			ReasonStarting,
			ReasonEnding,
			UserInitialStarting,
			UserInitialEnding,
			ResourceStarting,
			ResourceEnding,
			SortByTEJ,
			TransactionDateStartingOffset,
			TransactionDateEndingOffset,
			ViewCost,
			DisplayHeader,
			PMessageLanguage,
			pSite,
			BGUser);


			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
	}
}
