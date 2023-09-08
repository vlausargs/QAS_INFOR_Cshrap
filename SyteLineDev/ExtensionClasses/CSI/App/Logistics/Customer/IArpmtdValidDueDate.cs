//PROJECT NAME: Logistics
//CLASS NAME: IArpmtdValidDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdValidDueDate
	{
		(int? ReturnCode, DateTime? DueDate,
		string Infobar) ArpmtdValidDueDateSp(string InvNum,
		DateTime? DueDate,
		string Infobar);
	}
}

