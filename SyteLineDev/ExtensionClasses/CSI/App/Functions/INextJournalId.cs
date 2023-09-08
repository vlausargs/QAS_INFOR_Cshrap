//PROJECT NAME: Data
//CLASS NAME: INextJournalId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextJournalId
	{
		(int? ReturnCode,
			int? Seq,
			string Infobar) NextJournalIdSp(
			string Id,
			int? Increment = 1,
			int? Seq = null,
			string Infobar = null);
	}
}

