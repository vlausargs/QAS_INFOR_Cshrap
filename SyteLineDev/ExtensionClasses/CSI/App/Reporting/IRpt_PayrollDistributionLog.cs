//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PayrollDistributionLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PayrollDistributionLog
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PayrollDistributionLogSp(string EmployeeStarting = null,
		string EmployeeEnding = null,
		int? TransactionStatus = null,
		string EmployeeType = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null);
	}
}

