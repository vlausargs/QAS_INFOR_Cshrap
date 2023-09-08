//PROJECT NAME: Finance
//CLASS NAME: ITTJournalPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalPost
	{
		(int? ReturnCode, string Message,
		string Infobar) TTJournalPostSp(int? PCompressJournals,
		string PCompressionLevel,
		int? PDeleteJournals,
		DateTime? PReversingDate,
		int? PSingleDateForTnx,
		DateTime? PSingleDateToUse,
		DateTime? PPostThroughDate,
		string PJournalId,
		int? PLastSeq,
		Guid? SessionID,
		int? POverrideWarning,
		string Message,
		decimal? PJournalBatchId,
		string Infobar,
		string FSBName = null);
	}
}

