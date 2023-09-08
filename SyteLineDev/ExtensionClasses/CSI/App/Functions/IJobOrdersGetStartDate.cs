//PROJECT NAME: Data
//CLASS NAME: IJobOrdersGetStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobOrdersGetStartDate
	{
		(int? ReturnCode,
			decimal? PStartTick,
			decimal? PEndTick,
			DateTime? PEndDate,
			string Infobar) JobOrdersGetStartDateSp(
			string PJob,
			int? PSuffix,
			decimal? PStartTick,
			decimal? PEndTick,
			DateTime? PStartDate,
			DateTime? PEndDate,
			string Infobar);
	}
}

