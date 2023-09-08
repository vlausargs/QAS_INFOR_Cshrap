//PROJECT NAME: Logistics
//CLASS NAME: ICitemXJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICitemXJob
	{
		(int? ReturnCode,
			string CurJob,
			int? CurSuffix,
			string Infobar) CitemXJobSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			decimal? QtyOrdered,
			DateTime? DueDate,
			string Whse,
			string CurJob,
			int? CurSuffix,
			string Infobar,
			string ExportType);
	}
}

