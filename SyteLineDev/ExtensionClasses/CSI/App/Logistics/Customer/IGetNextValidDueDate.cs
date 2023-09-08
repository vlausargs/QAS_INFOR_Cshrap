//PROJECT NAME: Logistics
//CLASS NAME: IGetNextValidDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetNextValidDueDate
	{
		(int? ReturnCode, DateTime? DueDate,
		string Infobar) GetNextValidDueDateSp(string RefType,
		int? IsForward,
		string Site,
		DateTime? DueDate,
		string Infobar);

		DateTime? GetNextValidDueDateFn(
			string RefType,
			int? IsForward,
			DateTime? DueDate);
	}
}

