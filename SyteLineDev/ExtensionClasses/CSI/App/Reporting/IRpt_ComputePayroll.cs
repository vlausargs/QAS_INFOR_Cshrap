//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ComputePayroll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ComputePayroll
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ComputePayrollSp(string pSite = null);
	}
}

