//PROJECT NAME: Finance
//CLASS NAME: IJournalEntriesValidateId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalEntriesValidateId
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) JournalEntriesValidateIdSp(string PId,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string Callfrom = null,
		string GLVouchers = null);
	}
}

