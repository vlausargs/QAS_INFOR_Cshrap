//PROJECT NAME: Finance
//CLASS NAME: IGlJouc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGlJouc
	{
		(int? ReturnCode, string Infobar) GlJoucSp(DateTime? PPostDate,
		int? PLastSeq,
		string PPostLevel,
		string PJournalId,
		string Infobar,
		Guid? SessionID,
		string CalledFrom);
	}
}

