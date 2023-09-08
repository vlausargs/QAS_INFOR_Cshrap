//PROJECT NAME: Reporting
//CLASS NAME: IGLBudgetConsChartBp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGLBudgetConsChartBp
	{
		(int? ReturnCode,
			string rInfobar) GLBudgetConsChartBpSp(
			Guid? pChartBpRowPointer,
			int? pTgPeriodsMatch,
			string pCurrparmsCurrCode,
			string rInfobar);
	}
}

