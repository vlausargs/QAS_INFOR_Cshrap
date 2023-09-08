//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSLedgerPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSLedgerPost
	{
		(int? ReturnCode,
			string Infobar) EXTCHSLedgerPostSp(
			string pJournalId,
			int? pJournalSeq,
			decimal? pTransNum,
			DateTime? pTransDate,
			int? pReverse,
			Guid? pLedgerRowPointer,
			DateTime? pJournalDate,
			string Infobar = null);
	}
}

