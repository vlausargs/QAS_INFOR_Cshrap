//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBJournalDefer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBJournalDefer
	{
		(int? ReturnCode,
			Guid? Partition,
			string Infobar) MultiFSBJournalDeferSp(
			string JournalId = null,
			Guid? Partition = null,
			string Infobar = null);
	}
}

