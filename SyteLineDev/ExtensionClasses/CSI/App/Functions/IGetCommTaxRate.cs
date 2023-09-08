//PROJECT NAME: Data
//CLASS NAME: IGetCommTaxRateSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetCommTaxRate
	{
		decimal? GetCommTaxRateSp(
			string Slsman);
	}
}

