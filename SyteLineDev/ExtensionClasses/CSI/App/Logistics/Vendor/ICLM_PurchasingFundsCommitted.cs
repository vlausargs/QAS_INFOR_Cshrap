//PROJECT NAME: Logistics
//CLASS NAME: ICLM_PurchasingFundsCommitted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_PurchasingFundsCommitted
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchasingFundsCommittedSp(string Vend_Num = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? Detail = 0,
		string FilterString = null);
	}
}

