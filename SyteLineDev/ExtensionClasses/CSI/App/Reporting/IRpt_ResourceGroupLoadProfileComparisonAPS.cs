//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceGroupLoadProfileComparisonAPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ResourceGroupLoadProfileComparisonAPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupLoadProfileComparisonAPSSp(string RGIDStarting,
		string RGIDEnding,
		DateTime? StartDate = null,
		int? IntervalCount = 12,
		int? IntervalType = 3,
		int? AltNum = 0,
		int? AltNum2 = 0,
		int? GroupAllocOnly = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

