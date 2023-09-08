//PROJECT NAME: Data
//CLASS NAME: IIsValidDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsValidDueDate
	{
		int? IsValidDueDateFn(
			string RefType,
			DateTime? DueDate);
	}
}

