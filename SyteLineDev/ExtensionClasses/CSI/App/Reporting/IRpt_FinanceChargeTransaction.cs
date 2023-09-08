//PROJECT NAME: Reporting
//CLASS NAME: IRpt_FinanceChargeTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_FinanceChargeTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FinanceChargeTransactionSp(string CustomerStarting = null,
		string CustomerEnding = null,
		int? PDisplayHeader = null,
		Guid? PSessionID = null,
		string pSite = null);
	}
}

