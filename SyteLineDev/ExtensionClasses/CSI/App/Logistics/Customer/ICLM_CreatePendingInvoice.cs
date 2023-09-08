//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CreatePendingInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CreatePendingInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CreatePendingInvoiceSp(Guid? PProcessID,
		string PCustNum = null,
		string FormType = null,
		int? NonDraftCust = null,
		string PType = "I",
		string FilterString = null);
	}
}

