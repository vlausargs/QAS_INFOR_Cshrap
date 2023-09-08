//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBJournalImmediate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBJournalImmediate
	{
		(int? ReturnCode,
			string Infobar) MultiFSBJournalImmediateSp(
			Guid? Partition,
			string Infobar);
	}
}

