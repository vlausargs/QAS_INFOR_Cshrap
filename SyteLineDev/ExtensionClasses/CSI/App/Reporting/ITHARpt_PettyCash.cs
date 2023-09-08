//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_PettyCash.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_PettyCash
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_PettyCashSp(string StartingBankCode = null,
		string EndingBankCode = null,
		DateTime? StartingIssueDate = null,
		DateTime? EndingIssueDate = null,
		string StartingReference = null,
		string EndingReference = null,
		string pSite = null);
	}
}

