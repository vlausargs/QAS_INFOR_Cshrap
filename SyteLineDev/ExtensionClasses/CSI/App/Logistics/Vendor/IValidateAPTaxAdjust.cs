//PROJECT NAME: Logistics
//CLASS NAME: IValidateAPTaxAdjust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateAPTaxAdjust
	{
		(int? ReturnCode, string InfoBar) ValidateAPTaxAdjustSp(int? Voucher,
		decimal? DisAmt,
		int? TaxNum,
		decimal? Tax1,
		decimal? Tax2,
		string InfoBar);
	}
}

