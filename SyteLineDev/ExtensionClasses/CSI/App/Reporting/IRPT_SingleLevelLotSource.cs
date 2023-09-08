//PROJECT NAME: Reporting
//CLASS NAME: IRPT_SingleLevelLotSource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_SingleLevelLotSource
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_SingleLevelLotSourceSp(string StartingItem = null,
		string EndingItem = null,
		string StartingLot = null,
		string EndingLot = null,
		string SortBy = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

