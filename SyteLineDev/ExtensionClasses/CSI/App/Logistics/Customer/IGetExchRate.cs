//PROJECT NAME: Logistics
//CLASS NAME: IGetExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetExchRate
	{
		(int? ReturnCode, decimal? ExchRate,
		string Infobar) GetExchRateSp(string CustNum,
		DateTime? InvoiceDate,
		decimal? ExchRate,
		string Infobar);

		decimal? GetExchRateFn(
			string FromCurrCode,
			string ToCurrCode,
			DateTime? InvoiceDate,
			int? UseBuyRate);
	}
}

