//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBNextJournalId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBNextJournalId
	{
		(int? ReturnCode,
			int? Seq,
			string Infobar) MultiFSBNextJournalIdSp(
			string FSBName,
			string Id = "General",
			int? Increment = 1,
			int? Seq = null,
			string Infobar = null);
	}
}

