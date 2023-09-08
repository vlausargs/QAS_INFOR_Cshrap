//PROJECT NAME: Logistics
//CLASS NAME: IGetVendExchRate2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetVendExchRate2
	{
		(int? ReturnCode, decimal? ExchRate,
		string Infobar) GetVendExchRate2Sp(string PaymentBankCode,
		string VendNum,
		DateTime? CheckDate,
		decimal? ExchRate,
		string Infobar,
		int? UseBuyRate = 1);
	}
}

