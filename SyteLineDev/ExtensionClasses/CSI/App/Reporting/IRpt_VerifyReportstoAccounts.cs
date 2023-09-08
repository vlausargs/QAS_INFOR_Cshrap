//PROJECT NAME: Reporting
//CLASS NAME: IRpt_VerifyReportstoAccounts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_VerifyReportstoAccounts
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_VerifyReportstoAccountsSp(string AccountStarting = null,
		string AccountEnding = null,
		int? InvalidAccountsOnly = null,
		int? DisplayHeader = null,
		string PMessageLanguage = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

