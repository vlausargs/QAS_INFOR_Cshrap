//PROJECT NAME: Employee
//CLASS NAME: ICLM_PayrollCheckDateChart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_PayrollCheckDateChart
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PayrollCheckDateChartSp(string EmpNum);
	}
}

