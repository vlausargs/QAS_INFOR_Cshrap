//PROJECT NAME: Reporting
//CLASS NAME: IGLBudgetConsChartBpUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGLBudgetConsChartBpUpdate
	{
		(int? ReturnCode,
			string Infobar) GLBudgetConsChartBpUpdateSp(
			string pAcct,
			string pUnit1,
			string pUnit2,
			string pUnit3,
			string pUnit4,
			int? pChartBpFiscalYear,
			string pHierarchy,
			string Infobar,
			int? Period,
			decimal? ChartBpBudget__1,
			decimal? ChartBpBudget__2,
			decimal? ChartBpBudget__3,
			decimal? ChartBpBudget__4,
			decimal? ChartBpBudget__5,
			decimal? ChartBpBudget__6,
			decimal? ChartBpBudget__7,
			decimal? ChartBpBudget__8,
			decimal? ChartBpBudget__9,
			decimal? ChartBpBudget__10,
			decimal? ChartBpBudget__11,
			decimal? ChartBpBudget__12,
			decimal? ChartBpBudget__13,
			decimal? ChartBpPlan__1,
			decimal? ChartBpPlan__2,
			decimal? ChartBpPlan__3,
			decimal? ChartBpPlan__4,
			decimal? ChartBpPlan__5,
			decimal? ChartBpPlan__6,
			decimal? ChartBpPlan__7,
			decimal? ChartBpPlan__8,
			decimal? ChartBpPlan__9,
			decimal? ChartBpPlan__10,
			decimal? ChartBpPlan__11,
			decimal? ChartBpPlan__12,
			decimal? ChartBpPlan__13,
			decimal? ChartBpActual__1,
			decimal? ChartBpActual__2,
			decimal? ChartBpActual__3,
			decimal? ChartBpActual__4,
			decimal? ChartBpActual__5,
			decimal? ChartBpActual__6,
			decimal? ChartBpActual__7,
			decimal? ChartBpActual__8,
			decimal? ChartBpActual__9,
			decimal? ChartBpActual__10,
			decimal? ChartBpActual__11,
			decimal? ChartBpActual__12,
			decimal? ChartBpActual__13,
			Guid? SessionID);
	}
}

