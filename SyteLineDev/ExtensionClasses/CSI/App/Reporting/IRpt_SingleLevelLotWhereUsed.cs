//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SingleLevelLotWhereUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SingleLevelLotWhereUsed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SingleLevelLotWhereUsedSp(string PStartingItem = null,
		string PEndingItem = null,
		string PStartingLot = null,
		string PEndingLot = null,
		int? PSortBy = 1,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

