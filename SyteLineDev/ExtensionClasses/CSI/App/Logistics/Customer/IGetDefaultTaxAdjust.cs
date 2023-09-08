//PROJECT NAME: Logistics
//CLASS NAME: IGetDefaultTaxAdjust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetDefaultTaxAdjust
	{
		(int? ReturnCode, decimal? DfltTax1Val,
		decimal? DfltTax1Var,
		decimal? DfltTax2Val,
		decimal? DfltTax2Var) GetDefaultTaxAdjustSp(string InvoiceNumber,
		decimal? DisAmt,
		decimal? AllowAmt,
		decimal? DfltTax1Val,
		decimal? DfltTax1Var,
		decimal? DfltTax2Val,
		decimal? DfltTax2Var);
	}
}

