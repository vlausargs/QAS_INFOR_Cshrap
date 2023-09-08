//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InterPostedPayrollTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InterPostedPayrollTransactions
	{
		(int? ReturnCode,
			string Infobar) Rpt_InterPostedPayrollTransactionsSp(
			Guid? pPrtrxpRowPointer,
			int? pIdx,
			string pListTDe,
			string pListTAmt,
			int? pTCanCost,
			string Infobar);
	}
}

