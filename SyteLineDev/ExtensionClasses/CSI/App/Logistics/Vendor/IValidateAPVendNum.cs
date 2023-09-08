//PROJECT NAME: Logistics
//CLASS NAME: IValidateAPVendNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateAPVendNum
	{
		(int? ReturnCode, int? PayHold,
		string BankCode,
		string BankName,
		string PayType,
		string CurrCode,
		string VendName,
		decimal? ExchRate,
		int? IsFixedEuro,
		string PCurrAmtFormat,
		string Infobar) ValidateAPVendNumSp(string PVendNum,
		int? PayHold,
		string BankCode,
		string BankName,
		string PayType,
		string CurrCode,
		string VendName,
		decimal? ExchRate,
		int? IsFixedEuro,
		string PCurrAmtFormat,
		string Infobar);
	}
}

