//PROJECT NAME: Data
//CLASS NAME: IEstItemXJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEstItemXJob
	{
		(int? ReturnCode,
			string CurEstJob,
			int? CurEstSuffix,
			string Infobar) EstItemXJobSp(
			string EstNum,
			int? EstLine,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			decimal? QtyOrdered,
			DateTime? DueDate,
			string Whse,
			string CurEstJob,
			int? CurEstSuffix,
			string Infobar);
	}
}

