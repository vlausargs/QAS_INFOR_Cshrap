//PROJECT NAME: Finance
//CLASS NAME: IChartAllAcctValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chart
{
	public interface IChartAllAcctValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) ChartAllAcctValidSp(
			string SiteRef,
			string Acct,
			string Description,
			string Infobar);
	}
}

