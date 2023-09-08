//PROJECT NAME: Logistics
//CLASS NAME: IGetDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetDueDate
	{
		(int? ReturnCode, DateTime? DueDate,
		string Infobar) GetDueDateSp(string ArinvType,
		string TermsCode,
		DateTime? InvoiceDate,
		DateTime? DueDate,
		string Infobar);
	}
}

