//PROJECT NAME: Production
//CLASS NAME: IJournalDefer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalDefer
	{
		(int? ReturnCode,
			Guid? Partition,
			string Infobar) JournalDeferSp(
			string JournalId = null,
			Guid? Partition = null,
			string Infobar = null);
	}
}

