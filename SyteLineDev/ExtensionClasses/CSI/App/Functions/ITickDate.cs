//PROJECT NAME: Data
//CLASS NAME: ITickDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITickDate
	{
		(int? ReturnCode,
			DateTime? PDate,
			int? PTime) TickDateSp(
			decimal? PTick,
			DateTime? PDate,
			int? PTime);

		DateTime? TickDateFn(
			decimal? PTick);
	}
}

