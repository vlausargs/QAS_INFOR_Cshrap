//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetInvoiceNo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetInvoiceNo
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_GetInvoiceNoSp(
			string CustNum,
			int? Cancellation = 0);
	}
}

