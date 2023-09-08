//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ECSalesList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ECSalesList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECSalesListSP(string SiteGroup = null,
		DateTime? BeginInvStaxInvDate = null,
		DateTime? EndInvStaxInvDate = null,
		int? BeginInvStaxInvDateOffset = null,
		int? EndInvStaxInvDateOffset = null,
		string Eceslqtr = null,
		int? Eceslfrt = null,
		int? Eceslmsc = null,
		int? ShowDetail = null,
		string BeginCustNum = null,
		string EndCustNum = null,
		string BeginEcCode = null,
		string EndEcCode = null,
		string BeginProcessInd = null,
		string EndProcessInd = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		int? IncludeTransferOrders = null,
		string pSite = null);
	}
}

