//PROJECT NAME: Logistics
//CLASS NAME: IGetExchRate2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetExchRate2
	{
		(int? ReturnCode, decimal? ExchRate,
		string Infobar) GetExchRate2Sp(string FromCurrCode,
		string ToCurrCode,
		DateTime? InvoiceDate,
		decimal? ExchRate,
		string Infobar);
	}
}

