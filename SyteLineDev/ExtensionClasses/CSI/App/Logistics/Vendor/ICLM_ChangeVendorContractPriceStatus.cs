//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ChangeVendorContractPriceStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_ChangeVendorContractPriceStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ChangeVendorContractPriceStatusSp(string Process,
		string StartingVendor,
		string EndingVendor,
		string StartingItem,
		string EndingItem,
		DateTime? StartingDate,
		DateTime? EndingDate,
		int? StartingEffectDateOffset = null,
		int? EndingEffectDateOffset = null,
		string Infobar = null);
	}
}

