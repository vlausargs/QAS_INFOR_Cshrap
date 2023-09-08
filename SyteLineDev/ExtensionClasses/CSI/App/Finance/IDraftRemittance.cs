//PROJECT NAME: Finance
//CLASS NAME: IDraftRemittance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IDraftRemittance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DraftRemittanceSp(string RemOption = null,
		string BankCodeStarting = null,
		string BankCodeEnding = null,
		int? StartDraftNumber = null,
		int? EndDraftNumber = null);
	}
}

