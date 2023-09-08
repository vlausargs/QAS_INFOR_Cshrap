//PROJECT NAME: Logistics
//CLASS NAME: IGetCustExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCustExchRate
	{
		(int? ReturnCode, decimal? ExchRate,
		string Infobar) GetCustExchRateSp(string CustNum,
		string CurrCode,
		DateTime? InvoiceDate,
		decimal? ExchRate,
		string Infobar);
	}
}

