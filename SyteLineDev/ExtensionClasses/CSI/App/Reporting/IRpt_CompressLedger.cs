//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CompressLedger.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CompressLedger
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CompressLedgerSp(string ProcessId,
		int? AnalyticalLedger,
		DateTime? PerStart,
		DateTime? PerEnd,
		string AcctStart,
		string AcctEnd,
		string pSite = null);
	}
}

