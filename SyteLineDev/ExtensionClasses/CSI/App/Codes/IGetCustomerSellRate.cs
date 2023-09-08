//PROJECT NAME: Codes
//CLASS NAME: IGetCustomerSellRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetCustomerSellRate
	{
		(int? ReturnCode, decimal? SellRate) GetCustomerSellRateSp(string DomesticCurrCode,
		string CustomerCurrCode,
		decimal? SellRate);
	}
}

