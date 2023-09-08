//PROJECT NAME: Logistics
//CLASS NAME: IMultipleDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IMultipleDueDate
	{
		(int? ReturnCode,
		int? MultiDueDate) MultipleDueDateSp(
			string TermsCode,
			int? MultiDueDate);
	}
}

