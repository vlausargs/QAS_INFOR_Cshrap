//PROJECT NAME: Employee
//CLASS NAME: ICLM_PayrollCheckDateListing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_PayrollCheckDateListing
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_PayrollCheckDateListingSp(
			string EmpNum);
	}
}

