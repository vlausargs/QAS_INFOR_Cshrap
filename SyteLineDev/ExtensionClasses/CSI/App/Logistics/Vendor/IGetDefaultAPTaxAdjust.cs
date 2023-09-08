//PROJECT NAME: Logistics
//CLASS NAME: IGetDefaultAPTaxAdjust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetDefaultAPTaxAdjust
	{
		(int? ReturnCode, decimal? DfltTax1Val,
		decimal? DfltTax2Val) GetDefaultAPTaxAdjustSp(int? Voucher,
		decimal? DisAmt,
		decimal? DfltTax1Val,
		decimal? DfltTax2Val);
	}
}

