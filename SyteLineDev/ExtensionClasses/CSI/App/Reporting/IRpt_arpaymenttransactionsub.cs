//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ARPaymentTransactionSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ARPaymentTransactionSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARPaymentTransactionSubSp(Guid? ProcessId = null,
		string pSite = null);
	}
}

