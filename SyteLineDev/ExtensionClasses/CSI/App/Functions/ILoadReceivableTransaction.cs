//PROJECT NAME: Data
//CLASS NAME: ILoadReceivableTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILoadReceivableTransaction
	{
		int? LoadReceivableTransactionSp(
			string Customer,
			string ActionCode,
			string BilltoCustomer,
			decimal? Receievablebaseamount,
			string Infobar);
	}
}

