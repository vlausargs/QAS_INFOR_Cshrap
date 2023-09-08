//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobMaterialKitPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobMaterialKitPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobMaterialKitPickListSP(string StartingJob = null,
		int? StartingSuffix = null,
		string EndingJob = null,
		int? EndingSuffix = null,
		int? StartingOperNum = null,
		int? EndingOperNum = null,
		string StartingKit = null,
		string EndingKit = null,
		int? SortByLoc = null,
		int? PrintSecondaryLocations = null,
		int? ExtendByScrapFactor = null,
		int? PrintBarCode = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

