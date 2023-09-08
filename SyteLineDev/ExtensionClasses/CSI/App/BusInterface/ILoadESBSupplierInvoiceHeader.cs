//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBSupplierInvoiceHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBSupplierInvoiceHeader
	{
		(int? ReturnCode, string Infobar) LoadESBSupplierInvoiceHeaderSp(string ActionExpression = null,
		string SupplierInvoice = null,
		string VendNum = null,
		decimal? PreSubunitRoundedTotalAmount = null,
		decimal? SubunitRoundingAmount = null,
		string SubunitRoundingCurrCode = null,
		DateTime? InvDate = null,
		DateTime? DueDate = null,
		string Infobar = null);
	}
}

