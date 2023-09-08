//PROJECT NAME: Data
//CLASS NAME: IUpdateProFormaInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateProFormaInvoice
	{
		(int? ReturnCode,
			string Infobar) UpdateProFormaInvoiceSp(
			string PInvoiceNumber = null,
			Guid? PSessionID = null,
			string PInvoiceCreditType = null,
			string PCustNum = null,
			string POrderNumber = null,
			DateTime? PTransactionDate = null,
			string ActionExpression = null,
			string Infobar = null,
			string ApplyToInvoice = null);
	}
}

