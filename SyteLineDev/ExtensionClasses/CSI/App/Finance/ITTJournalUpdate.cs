//PROJECT NAME: Finance
//CLASS NAME: ITTJournalUpda.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalUpda
	{
		(int? ReturnCode, string Infobar) TTJournalUpdate(Guid? PRowPointer,
		int? PPost,
		string PJStatus,
		string Infobar);
	}
}

