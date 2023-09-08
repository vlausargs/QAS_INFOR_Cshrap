//PROJECT NAME: Finance
//CLASS NAME: ILedgerCompressSnapshot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ILedgerCompressSnapshot
	{
		(int? ReturnCode, string Infobar) LedgerCompressSnapshotSp(Guid? ProcessId,
		DateTime? PTransDateStart,
		DateTime? PTransDateEnd,
		string PAcctStart,
		string PAcctEnd,
		int? PAnalyticalLedger,
		string Infobar);
	}
}

