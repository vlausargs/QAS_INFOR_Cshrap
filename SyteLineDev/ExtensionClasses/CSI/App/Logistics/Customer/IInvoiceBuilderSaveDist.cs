//PROJECT NAME: Logistics
//CLASS NAME: IInvoiceBuilderSaveDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvoiceBuilderSaveDist
	{
		int? InvoiceBuilderSaveDistSp(Guid? PRowPointer,
		Guid? PProcessId = null,
		int? PSelected = null,
		string PCustNum = null,
		int? PClearSel = 0);
	}
}

