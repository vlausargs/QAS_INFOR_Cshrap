//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectTransactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectTransactionsSp(string StartingProject = null,
		string EndingProject = null,
		string CostClass = null,
		string ProjectStatus = null,
		int? StartingTask = null,
		int? EndingTask = null,
		DateTime? StartingTransDate = null,
		int? StartingTransDateOffset = null,
		DateTime? EndingTransDate = null,
		int? EndingTransDateOffset = null,
		string StartingCostCode = null,
		string EndingCostCode = null,
		int? PrintCost = 0,
		int? DisplayHeader = 1,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null);
	}
}

