//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TransferPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TransferPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferPackingSlipSp(int? MinPackNum = null,
		int? MaxPackNum = null,
		int? PrINTOrderText = 0,
		int? PrINTLineText = 0,
		int? ShowINTernal = 0,
		int? ShowExternal = 0,
		int? DisplayHeader = 0,
		string TrnStat = "TC",
		string TrnitemStat = "TC",
		string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderLineEnding = null,
		string SiteStarting = null,
		string SiteEnding = null,
		string FromWhseStarting = null,
		string FromWhseEnding = null,
		string ToWhseStarting = null,
		string ToWhseEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string pSite = null);
	}
}

