//PROJECT NAME: Production
//CLASS NAME: IJobOrdersPreSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobOrdersPreSave
	{
		(int? ReturnCode, DateTime? PStartDate,
		DateTime? PEndDate,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar) JobOrdersPreSaveSp(string PJob,
		int? PSuffix,
		string PJobType,
		string PItem,
		decimal? PQtyReleased,
		int? PCoProductMix,
		string POrdType,
		string POrdNum,
		int? POrdLine,
		int? POrdRelease,
		string OldStat,
		string NewStat,
		DateTime? PStartDate,
		DateTime? PEndDate,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar);
	}
}

