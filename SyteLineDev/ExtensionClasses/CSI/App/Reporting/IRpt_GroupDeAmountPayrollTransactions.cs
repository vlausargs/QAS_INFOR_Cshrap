//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GroupDeAmountPayrollTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GroupDeAmountPayrollTransactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_GroupDeAmountPayrollTransactionsSp(
			string pSessionID = null,
			string pDept = null);
	}
}

