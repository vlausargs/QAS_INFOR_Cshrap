//PROJECT NAME: Production
//CLASS NAME: IJournalImmediate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalImmediate
	{
		(int? ReturnCode,
			string Infobar) JournalImmediateSp(
			Guid? Partition,
			string Infobar,
			int? BypassBalanceCheck = 0);
	}
}

