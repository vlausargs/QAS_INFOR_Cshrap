//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSDeleteChJournal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSDeleteChJournal
	{
		(int? ReturnCode,
			string Infobar) EXTCHSDeleteChJournalSp(
			string Infobar);
	}
}

