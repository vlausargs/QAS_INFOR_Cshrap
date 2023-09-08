//PROJECT NAME: Logistics
//CLASS NAME: IMaterialDistributionCustUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IMaterialDistributionCustUpd
	{
		int? MaterialDistributionCustUpdSp(Guid? ConnectionId,
		string VchType,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string GrnNum,
		int? GrnLine,
		string Item,
		string ItemDescription,
		string TransNat,
		string TransNat2,
		string UM,
		string TermsCode,
		decimal? QtuQtyReceived,
		decimal? QtuQtyVoucher,
		decimal? CprItemCost,
		decimal? CprItemCostConv,
		decimal? CprPlanCostConv,
		DateTime? PoRecordDate);
	}
}

