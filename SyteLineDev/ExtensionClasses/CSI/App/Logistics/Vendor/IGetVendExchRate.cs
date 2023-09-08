//PROJECT NAME: Logistics
//CLASS NAME: IGetVendExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetVendExchRate
	{
		(int? ReturnCode, decimal? ExchRate,
		string Infobar) GetVendExchRateSp(string VendNum,
		DateTime? CheckDate,
		string CurrCode,
		decimal? ExchRate,
		string Infobar,
		int? UseBuyRate = 0);
	}
}

