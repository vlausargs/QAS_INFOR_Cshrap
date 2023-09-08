//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TransferOrderKitPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TransferOrderKitPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransferOrderKitPickListSP(string StartingTrnNum = null,
		string EndingTrnNum = null,
		int? StartingLineNum = null,
		int? EndingLineNum = null,
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

