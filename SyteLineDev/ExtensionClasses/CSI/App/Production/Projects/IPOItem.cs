//PROJECT NAME: Production
//CLASS NAME: IPOItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IPOItem
	{
		(int? ReturnCode, DateTime? DueDate,
		int? RowsCount) POItemSp(string RefNum,
		int? RefLineSuf,
		DateTime? DueDate,
		int? RowsCount);
	}
}

