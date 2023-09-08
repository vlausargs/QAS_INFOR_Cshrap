//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ArSumFinanceChargeTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ArSumFinanceChargeTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ArSumFinanceChargeTransactionSp(string CustomerStarting = null,
		string CustomerEnding = null,
		int? PDisplayHeader = null,
		Guid? PSessionID = null,
		string pSite = null,
		string GroupBy = null);
	}
}

