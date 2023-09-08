//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PrintW2Forms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PrintW2Forms
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintW2FormsSp(DateTime? YearStartDate,
		DateTime? YearEndDate,
		int? W3Information = 0,
		int? ConsolidateState = 0,
		string EmpNumStarting = null,
		string EmpNumEnding = null,
		int? EmpTypeHourlyPerm = null,
		int? EmpTypeSalaryPerm = null,
		string pSite = null);
	}
}

