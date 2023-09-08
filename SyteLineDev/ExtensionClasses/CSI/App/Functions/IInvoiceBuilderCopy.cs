//PROJECT NAME: Data
//CLASS NAME: IInvoiceBuilderCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvoiceBuilderCopy
	{
		(int? ReturnCode,
			string Infobar) InvoiceBuilderCopySp(
			Guid? PProcessId,
			string PToSite,
			int? PSelected = null,
			string PBuilderInvNum = null,
			string PBuilderInvOrigSite = null,
			string PCoNum = null,
			int? PCoLine = null,
			int? PCoRelease = null,
			Guid? PCoRowPointer = null,
			Guid? PCoitemRowPointer = null,
			decimal? PCost = null,
			string PCustNum = null,
			string PItem = null,
			string PItemDescription = null,
			string PUM = null,
			decimal? POrigQtyInvoice = null,
			decimal? PPrice = null,
			decimal? PQtyInvoice = null,
			decimal? PQtyOrdered = null,
			decimal? PQtyReturned = null,
			decimal? PQtyShipped = null,
			DateTime? PShipDate = null,
			string Infobar = null);
	}
}

