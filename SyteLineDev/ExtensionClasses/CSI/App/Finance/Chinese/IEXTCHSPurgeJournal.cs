//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSPurgeJournal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSPurgeJournal
	{
		(int? ReturnCode,
			string Infobar) EXTCHSPurgeJournalSp(
			string JournalId,
			DateTime? CutoffDate,
			int? CutoffDateOffset = null,
			string Infobar = null);
	}
}

