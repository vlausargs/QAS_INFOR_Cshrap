//PROJECT NAME: Data
//CLASS NAME: INextBuilderInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextBuilderInvoice
	{
		(int? ReturnCode,
			string NewBuilderInvoiceNum,
			string Infobar) NextBuilderInvoiceSp(
			string NewBuilderInvoiceNum,
			string Infobar);
	}
}

