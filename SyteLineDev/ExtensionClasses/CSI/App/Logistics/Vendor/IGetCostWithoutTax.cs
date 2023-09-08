//PROJECT NAME: Logistics
//CLASS NAME: IGetCostWithoutTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetCostWithoutTax
	{
		(int? ReturnCode, decimal? CostWithoutTax,
		string Infobar) GetCostWithoutTaxSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		DateTime? TransDate,
		decimal? CostAmount,
		decimal? CostWithoutTax,
		string Infobar);
	}
}

