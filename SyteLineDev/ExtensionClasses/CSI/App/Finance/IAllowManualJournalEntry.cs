//PROJECT NAME: Finance
//CLASS NAME: IAllowManualJournalEntry.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IAllowManualJournalEntry
	{
		(int? ReturnCode, string Infobar) AllowManualJournalEntrySp(string GroupName,
		decimal? UserId,
		string pAcctNumber,
		int? IsSecureCtlAcct,
		string Infobar);
	}
}

