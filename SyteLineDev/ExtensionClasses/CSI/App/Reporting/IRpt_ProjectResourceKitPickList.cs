//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectResourceKitPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectResourceKitPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectResourceKitPickListSp(string StartingProjNum = null,
		string EndingProjNum = null,
		int? StartingTaskNum = null,
		int? EndingTaskNum = null,
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

