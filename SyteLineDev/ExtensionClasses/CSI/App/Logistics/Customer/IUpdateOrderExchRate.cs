//PROJECT NAME: Logistics
//CLASS NAME: IUpdateOrderExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdateOrderExchRate
	{
		(int? ReturnCode, decimal? ExchRate,
		string Infobar) UpdateOrderExchRateSp(string CurrCode,
		DateTime? OrderDate,
		decimal? ExchRate,
		string Infobar);
	}
}

