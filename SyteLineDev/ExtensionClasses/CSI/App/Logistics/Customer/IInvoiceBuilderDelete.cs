//PROJECT NAME: Logistics
//CLASS NAME: IInvoiceBuilderDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvoiceBuilderDelete
	{
		int? InvoiceBuilderDeleteSp(Guid? PProcessID,
		string PCustNum = null);
	}
}

