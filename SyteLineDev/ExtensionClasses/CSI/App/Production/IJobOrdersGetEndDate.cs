//PROJECT NAME: Production
//CLASS NAME: IJobOrdersGetEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobOrdersGetEndDate
	{
		(int? ReturnCode, decimal? PStartTick,
		decimal? PEndTick,
		DateTime? PEndDate,
		string Infobar) JobOrdersGetEndDateSp(string PJob,
		int? PSuffix,
		decimal? PStartTick,
		decimal? PEndTick,
		DateTime? PStartDate,
		DateTime? PEndDate,
		string Infobar);
	}
}

