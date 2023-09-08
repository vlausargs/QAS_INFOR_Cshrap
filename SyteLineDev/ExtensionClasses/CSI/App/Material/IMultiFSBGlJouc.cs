//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBGlJouc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBGlJouc
	{
		(int? ReturnCode,
			string Infobar) MultiFSBGlJoucSp(
			string FSBName,
			DateTime? PPostDate,
			int? PLastSeq,
			string PPostLevel,
			string PJournalId,
			string Infobar,
			Guid? SessionID);
	}
}

