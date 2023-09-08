//PROJECT NAME: Data
//CLASS NAME: IRepApsTrnitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepApsTrnitem
	{
		(int? ReturnCode,
			string Infobar) RepApsTrnitemSp(
			string TrnNum,
			int? TrnLine,
			DateTime? ProjectedDate,
			string Infobar,
			int? BulkMode = 0,
			Guid? ProcessId = null,
			string FromSite = null);
	}
}

