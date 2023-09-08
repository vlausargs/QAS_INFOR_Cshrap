//PROJECT NAME: Finance
//CLASS NAME: IMassJournalPostBk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMassJournalPostBk
	{
		(int? ReturnCode, string Infobar) MassJournalPostBkSp(int? CompressJournals,
		string CompressionLevel,
		int? JournalsToPost,
		int? OverrideWarning,
		decimal? UserId,
		string CurrentCultureName,
		string Infobar);
	}
}

