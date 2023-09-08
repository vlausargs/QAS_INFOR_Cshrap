//PROJECT NAME: Logistics
//CLASS NAME: IVchDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVchDel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) VchDelSp(int? EndingVoucher,
		DateTime? EndingInvoiceDate,
		int? DeleteLineItemsOnly,
		int? ShowUnpurgableVoucher,
		string Infobar,
		int? InvoiceDateOffset = null);
	}
}

