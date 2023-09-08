//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSupplierInvoiceLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSupplierInvoiceLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSupplierInvoiceLineSp(int? Voucher);
	}
}

