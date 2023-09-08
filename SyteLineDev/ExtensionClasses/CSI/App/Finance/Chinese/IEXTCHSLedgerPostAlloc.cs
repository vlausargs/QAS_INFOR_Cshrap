//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSLedgerPostAlloc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSLedgerPostAlloc
	{
		(int? ReturnCode,
			string Infobar) EXTCHSLedgerPostAllocSp(
			string pJournalId,
			string Infobar = null);
	}
}

