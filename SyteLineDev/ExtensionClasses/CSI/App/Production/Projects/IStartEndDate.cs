//PROJECT NAME: Production
//CLASS NAME: IStartEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IStartEndDate
	{
		(int? ReturnCode, DateTime? StartDate,
		DateTime? EndDate,
		int? RowCount) StartEndDateSp(string RefNum,
		int? RefLineSuf,
		DateTime? StartDate,
		DateTime? EndDate,
		int? RowCount);
	}
}

