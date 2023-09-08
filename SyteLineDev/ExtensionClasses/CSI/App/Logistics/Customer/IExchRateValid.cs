//PROJECT NAME: Logistics
//CLASS NAME: IExchRateValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IExchRateValid
	{
		(int? ReturnCode, string Infobar) ExchRateValidSp(string CurrCode,
		DateTime? TransDate,
		decimal? ExchRate,
		string Infobar);
	}
}

