//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GenerateLCTaxDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_GenerateLCTaxDist
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateLCTaxDistSp(string PVendNum,
		decimal? PFreight,
		decimal? PBrokerage,
		decimal? PDuty,
		decimal? PLocFreight,
		decimal? PInsurance,
		DateTime? PInvDate,
		int? GenerateTax,
		string FilterString = null);
	}
}

