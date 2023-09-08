//PROJECT NAME: Finance
//CLASS NAME: IJournalBuilderProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalBuilderProcess
	{
		int? JournalBuilderProcessSp(DateTime? PTransactionDate,
		string PToSite,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PDomAmount,
		string PRef,
		string PControlPrefix,
		string PControlSite,
		int? PControlYear,
		int? PControlPeriod,
		decimal? PControlNumber);
	}
}

