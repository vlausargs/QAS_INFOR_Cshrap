//PROJECT NAME: Finance
//CLASS NAME: IExtFinDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinDueDate
	{
		(int? ReturnCode,
			DateTime? DueDate) ExtFinDueDateSp(
			DateTime? InvoiceDate,
			int? DueDays,
			int? ProxCode,
			int? ProxDay,
			string pTermsCode,
			DateTime? DueDate = null);
	}
}

