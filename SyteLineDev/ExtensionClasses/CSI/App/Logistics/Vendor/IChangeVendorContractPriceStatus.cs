//PROJECT NAME: Logistics
//CLASS NAME: IChangeVendorContractPriceStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IChangeVendorContractPriceStatus
	{
		(int? ReturnCode,
		string Infobar) ChangeVendorContractPriceStatusSp(
			string Item,
			string VendNum,
			DateTime? EffectDate,
			string Stat,
			string Infobar);
	}
}

