//PROJECT NAME: Reporting
//CLASS NAME: IRpt_IndentedWBSCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_IndentedWBSCost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_IndentedWBSCostSp(string WBSNumber,
		int? Detail = 1,
		int? DisplayHeader = 1,
		string pSite = null,
		string BGUser = null);
	}
}

