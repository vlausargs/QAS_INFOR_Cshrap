//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetIGFCurrencyCodes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetIGFCurrencyCodes
	{
		(int? ReturnCode,
			string Infobar) ExtFinGetIGFCurrencyCodesSp(
			string Infobar);
	}
}

