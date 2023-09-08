//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectWIPValueByAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectWIPValueByAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectWIPValueByAccountSp(string StartingAccount = null,
		string EndingAccount = null,
		string StartingProdCode = null,
		string EndingProdCode = null,
		string ProjectStatus = null,
		int? PUnitCode1 = 0,
		int? PUnitCode2 = 0,
		int? PUnitCode3 = 0,
		int? PUnitCode4 = 0,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

