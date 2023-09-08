//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBUpdateChartAndUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBUpdateChartAndUnit
	{
		int? MultiFSBUpdateChartAndUnitSp(
			string site,
			string FSBCOAName,
			string FSBAcct);
	}
}

