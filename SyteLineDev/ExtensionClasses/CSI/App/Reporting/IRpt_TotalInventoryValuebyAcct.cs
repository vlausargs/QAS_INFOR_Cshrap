//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TotalInventoryValuebyAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TotalInventoryValuebyAcct
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TotalInventoryValuebyAcctSp(string AccountStarting = null,
		string AccountEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		string LocStarting = null,
		string LocEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string MaterialStatus = null,
		string MaterialType = null,
		string Source = null,
		string ABCCode = null,
		int? AcctUnit1 = null,
		int? AcctUnit2 = null,
		int? AcctUnit3 = null,
		int? AcctUnit4 = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

