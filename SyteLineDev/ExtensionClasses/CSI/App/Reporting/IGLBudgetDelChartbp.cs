//PROJECT NAME: Reporting
//CLASS NAME: IGLBudgetDelChartbp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGLBudgetDelChartbp
	{
		(int? ReturnCode,
			string Infobar) GLBudgetDelChartbpSp(
			string pHierarchy,
			string Infobar);
	}
}

