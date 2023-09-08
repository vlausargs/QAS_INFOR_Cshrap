//PROJECT NAME: Data
//CLASS NAME: ILoadPayableTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILoadPayableTransaction
	{
		(int? ReturnCode,
			string Infobar) LoadPayableTransactionSp(
			string Vendor,
			string ActionCode,
			string RemittoVendor,
			decimal? PayableAmount,
			DateTime? DocumentDateTime,
			string Infobar);
	}
}

