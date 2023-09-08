//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetIGFCurrencyRates.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetIGFCurrencyRates
	{
		(int? ReturnCode,
			string Infobar) ExtFinGetIGFCurrencyRatesSp(
			string Infobar);
	}
}

