//PROJECT NAME: Material
//CLASS NAME: IRcptsLeaveDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRcptsLeaveDueDate
	{
		(int? ReturnCode, string Infobar) RcptsLeaveDueDateSp(DateTime? DueDate,
		string Item,
		Guid? NewRowPointer,
		string Infobar);
	}
}

