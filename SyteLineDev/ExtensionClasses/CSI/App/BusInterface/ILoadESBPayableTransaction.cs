//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBPayableTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBPayableTransaction
	{
		(int? ReturnCode, string Infobar) LoadESBPayableTransactionSp(string Vendor,
		string ActionCode,
		string RemittoVendor,
		decimal? PayableAmount,
		string VendorCurrCode,
		DateTime? DocumentDateTime,
		string Infobar);
	}
}

