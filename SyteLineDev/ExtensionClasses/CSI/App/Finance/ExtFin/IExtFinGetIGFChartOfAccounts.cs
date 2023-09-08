//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetIGFChartOfAccounts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetIGFChartOfAccounts
	{
		(int? ReturnCode,
			string Infobar) ExtFinGetIGFChartOfAccountsSp(
			string Infobar);
	}
}

