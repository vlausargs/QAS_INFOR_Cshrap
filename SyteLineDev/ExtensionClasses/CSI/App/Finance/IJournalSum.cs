//PROJECT NAME: Finance
//CLASS NAME: IJournalSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalSum
	{
		(ICollectionLoadResponse Data, int? ReturnCode) JournalSumSp(string PJournalID,
		string FilterString);
	}
}

