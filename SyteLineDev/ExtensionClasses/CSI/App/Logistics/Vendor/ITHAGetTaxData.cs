//PROJECT NAME: Logistics
//CLASS NAME: ITHAGetTaxData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITHAGetTaxData
	{
		(int? ReturnCode, decimal? TaxAmount,
		string Infobar) THAGetTaxDataSp(string TaxCode,
		decimal? ForAmtPaid,
		string CurrCode,
		decimal? TaxAmount,
		string Infobar);
	}
}

