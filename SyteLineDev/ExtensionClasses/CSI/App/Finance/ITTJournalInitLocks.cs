//PROJECT NAME: Finance
//CLASS NAME: ITTJournalInitLocks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalInitLocks
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) TTJournalInitLocksSp(int? OverrideLock = 0,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		int? CallFromBG = 0,
		decimal? UserId = 0,
		string CallFormCap = null);
	}
}

