//PROJECT NAME: Employee
//CLASS NAME: IRpt_ExEmployeeOutstandingLoans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRpt_ExEmployeeOutstandingLoans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ExEmployeeOutstandingLoansSp(string EmployeeStarting = null,
		string EmployeeEnding = null,
		DateTime? HireDateStarting = null,
		DateTime? HireDateEnding = null,
		DateTime? TermDateStarting = null,
		DateTime? TermDateEnding = null,
		int? HireDateStartingOffset = null,
		int? HireDateEndingOffset = null,
		int? TermDateStartingOffset = null,
		int? TermDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

