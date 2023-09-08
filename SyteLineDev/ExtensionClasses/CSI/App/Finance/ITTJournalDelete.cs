//PROJECT NAME: Finance
//CLASS NAME: ITTJournalDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalDelete
	{
		(int? ReturnCode, string Infobar) TTJournalDeleteSp(string Infobar);
	}
}

