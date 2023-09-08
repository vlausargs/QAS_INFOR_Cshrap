//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBCompressLedger.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBCompressLedger
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBCompressLedgerSp(string ProcessId,
		DateTime? PerStart,
		DateTime? PerEnd,
		string AcctStart,
		string AcctEnd,
		string FSBNameStart,
		string FSBNameEnd,
		string pSite = null);
	}
}

