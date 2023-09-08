//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CostToCompleteLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CostToCompleteLog
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_CostToCompleteLogSp(
			string ProjectStarting = null,
			string ProjectEnding = null,
			int? TaskStarting = null,
			int? TaskEnding = null,
			string CostCodeStarting = null,
			string CostCodeEnding = null,
			string ProjectStatus = null,
			DateTime? Date = null,
			int? DateOffset = null,
			int? Printcost = 0,
			int? DisplayHeader = 1,
			string pSite = null);
	}
}

