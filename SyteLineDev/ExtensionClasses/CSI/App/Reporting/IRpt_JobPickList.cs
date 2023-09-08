//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobPickListSp(string Job = null,
			int? Suffix = null,
			string Item = null,
			string Whse = null,
			DateTime? PostDate = null,
			int? StartingOperNum = null,
			int? EndingOperNum = null,
			int? SortByLoc = null,
			int? IncludeSerialNumbers = null,
			int? ReprintPickListItems = null,
			int? PostMaterialIssues = null,
			int? PageBetweenOperations = null,
			int? PrintSecondaryLocations = null,
			int? ExtendByScrapFactor = null,
			int? PrintBarCode = null,
			int? DisplayHeader = null,
			string PMessageLanguage = null,
			int? TaskID = null,
			decimal? UserID = null,
			string BGSessionId = null,
			string pSite = null);
	}
}

