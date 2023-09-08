//PROJECT NAME: Reporting
//CLASS NAME: IRpt_BankReconciliation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_BankReconciliation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_BankReconciliationSp(string StartBankCode = null,
			string EndBankCode = null,
			DateTime? StartTransDate = null,
			DateTime? EndTransDate = null,
			int? StartTransNum = null,
			int? EndTransNum = null,
			int? IncludeVoidChecks = null,
			int? IncludeReconciled = null,
			string SortBy = null,
			int? DisplayReasonCodes = null,
			int? DisplayRefFields = null,
			string BankRecTypes = null,
			int? StartDateOffset = null,
			int? EndDateOffset = null,
			int? DisplayHeader = null,
			string BGSessionId = null,
			string pSite = null,
			string BGUser = null);
	}
}

