//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RecentPurchases.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RecentPurchases
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RecentPurchasesSp(string StartingItem = null,
		string EndingItem = null,
		string StartingBuyer = null,
		string EndingBuyer = null,
		string StartingVendor = null,
		string EndingVendor = null,
		DateTime? StartingDueDate = null,
		DateTime? EndingDueDate = null,
		int? TranslateCurrency = null,
		int? StartingDueDateOffset = null,
		int? EndingDueDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

