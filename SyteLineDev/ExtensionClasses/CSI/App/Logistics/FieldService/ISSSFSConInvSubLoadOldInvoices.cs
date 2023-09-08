//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubLoadOldInvoices.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubLoadOldInvoices
	{
		int? SSSFSConInvSubLoadOldInvoicesSp(
			Guid? SessionId,
			string Contract,
			int? ContLine);
	}
}

