//PROJECT NAME: Production
//CLASS NAME: IJobPick.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobPick
	{
		(int? ReturnCode,
			int? Counter,
			string Infobar) JobPickSp(
			string Job,
			int? Suffix,
			string Whse,
			int? StartingOperNum,
			int? EndingOperNum,
			int? SortByLoc,
			int? IncludeSerialNumbers,
			int? ReprintPickListItems,
			int? PrintSecondaryLocations,
			int? ExtendByScrapFactor,
			int? PostMaterialIssues,
			decimal? PickQty,
			DateTime? PostDate,
			int? Counter,
			string Infobar);
	}
}

