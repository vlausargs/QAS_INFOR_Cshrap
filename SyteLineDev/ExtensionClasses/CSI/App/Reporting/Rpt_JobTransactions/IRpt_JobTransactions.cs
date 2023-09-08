//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobTransactions
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_JobTransactionsSp(
			string TransactionType = null,
			string PayType = null,
			string Posted = null,
			string EmployeeType = null,
			int? ShowDetail = null,
			string BackflushTransaction = null,
			string EmployeeStarting = null,
			string EmployeeEnding = null,
			string JobStarting = null,
			string JobEnding = null,
			int? SuffixStarting = null,
			int? SuffixEnding = null,
			DateTime? TransactionDateStarting = null,
			DateTime? TransactionDateEnding = null,
			decimal? TransactionNumberStarting = null,
			decimal? TransactionNumberEnding = null,
			string ShiftStarting = null,
			string ShiftEnding = null,
			string ReasonStarting = null,
			string ReasonEnding = null,
			string UserInitialStarting = null,
			string UserInitialEnding = null,
			string ResourceStarting = null,
			string ResourceEnding = null,
			string SortByTEJ = null,
			int? TransactionDateStartingOffset = null,
			int? TransactionDateEndingOffset = null,
			int? ViewCost = null,
			int? DisplayHeader = null,
			string PMessageLanguage = null,
			string pSite = null,
			string BGUser = null);
	}
}

