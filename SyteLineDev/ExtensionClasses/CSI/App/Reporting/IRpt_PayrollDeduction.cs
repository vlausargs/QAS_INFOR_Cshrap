//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PayrollDeduction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PayrollDeduction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PayrollDeductionSp(DateTime? CheckDate = null,
		string EmpStarting = null,
		string EmpEnding = null,
		int? PrintAllTrx = null,
		string EmpType = null,
		int? CheckDateOffset = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null,
		string BGUser = null);
	}
}

