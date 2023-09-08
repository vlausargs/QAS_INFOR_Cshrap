//PROJECT NAME: Data
//CLASS NAME: IGetTransExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTransExchRate
	{
		decimal? GetTransExchRateFn(
			string FromCurrCode,
			string ToCurrCode,
			DateTime? InvoiceDate,
			int? UseBuyRate,
			decimal? PRate);
	}
}

