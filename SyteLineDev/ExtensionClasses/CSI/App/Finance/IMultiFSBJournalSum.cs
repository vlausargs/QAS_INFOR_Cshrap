//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBJournalSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBJournalSum
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MultiFSBJournalSumSp(string FSB,
		string FilterString);
	}
}

