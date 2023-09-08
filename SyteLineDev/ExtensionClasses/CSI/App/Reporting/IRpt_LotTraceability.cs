//PROJECT NAME: Reporting
//CLASS NAME: IRpt_LotTraceability.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_LotTraceability
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_LotTraceabilitySp(string PStartingItem = null,
		string PEndingItem = null,
		string PStartingLot = null,
		string PEndingLot = null,
		string PSummaryDetail = "D",
		string PSortBy = "L",
		int? PDisplayHeader = 1,
		string PMessageLanguage = null,
		string pSite = null);
	}
}

