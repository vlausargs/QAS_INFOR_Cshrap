//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCalcWorkDuration.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCalcWorkDuration
	{
		(int? ReturnCode,
			int? OMonths,
			int? OWeeks,
			int? ODays,
			decimal? OHours,
			string Infobar) SSSFSConInvSubCalcWorkDurationSp(
			string IUnitOfRate,
			DateTime? IStartDate,
			DateTime? IEndDate,
			int? OMonths,
			int? OWeeks,
			int? ODays,
			decimal? OHours,
			string Infobar);
	}
}

