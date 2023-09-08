//PROJECT NAME: Finance
//CLASS NAME: ILedgerPostingForJourClose.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ILedgerPostingForJourClose
	{
		(int? ReturnCode, string Infobar) LedgerPostingForJourCloseSp(Guid? PSessionID,
		string Infobar);
	}
}

