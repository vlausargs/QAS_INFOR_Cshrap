//PROJECT NAME: Finance
//CLASS NAME: ITTJournalLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) TTJournalLoadSp(int? PRebuildTable,
		DateTime? PostDate,
		Guid? SessionID = null,
		int? CallFromBG = 0);
	}
}

