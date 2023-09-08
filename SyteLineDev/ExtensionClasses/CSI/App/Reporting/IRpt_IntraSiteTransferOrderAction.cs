//PROJECT NAME: Reporting
//CLASS NAME: IRpt_IntraSiteTransferOrderAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_IntraSiteTransferOrderAction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_IntraSiteTransferOrderActionSp(string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		DateTime? StartDateBeg = null,
		DateTime? StartDateEnd = null,
		int? StartDateBegOffset = null,
		int? StartDateEndOffset = null,
		string Source = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

