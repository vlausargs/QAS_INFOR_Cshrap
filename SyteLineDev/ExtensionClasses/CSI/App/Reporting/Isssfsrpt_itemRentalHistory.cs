//PROJECT NAME: Reporting
//CLASS NAME: Isssfsrpt_itemRentalHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface Isssfsrpt_itemRentalHistory
	{
		(ICollectionLoadResponse Data, int? ReturnCode) sssfsrpt_itemRentalHistorySp(string ItemStarting = null,
		string ItemEnding = null,
		string SerNumStarting = null,
		string SerNumEnding = null,
		string CustNumStarting = null,
		string CustNumEnding = null,
		string ContractStarting = null,
		string ContractEnding = null,
		DateTime? InvDateStarting = null,
		DateTime? InvDateEnding = null,
		DateTime? StartDateStarting = null,
		DateTime? StartDateEnding = null,
		int? IncOpenContract = 1,
		string pSite = null);
	}
}

