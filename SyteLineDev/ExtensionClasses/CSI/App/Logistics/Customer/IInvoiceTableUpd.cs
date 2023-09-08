//PROJECT NAME: Logistics
//CLASS NAME: IInvoiceTableUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvoiceTableUpd
	{
		(int? ReturnCode, string Infobar) InvoiceTableUpdSp(string pInvNum,
		int? pInvSeq,
		int? pPostFromCo,
		DateTime? pTaxDate,
		decimal? pExchRate,
		string Infobar);
	}
}

