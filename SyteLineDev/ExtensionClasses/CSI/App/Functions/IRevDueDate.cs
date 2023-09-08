//PROJECT NAME: Data
//CLASS NAME: IRevDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRevDueDate
	{
		(int? ReturnCode,
			DateTime? DueDate) RevDueDateSp(
			string CustomerNumber,
			string InvoicNumber,
			int? InvoiceSequence,
			DateTime? InvoiceDate,
			string TermsCode,
			int? DueDays,
			int? ProxCode,
			int? ProxDay,
			DateTime? DueDate);
	}
}

