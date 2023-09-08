//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SupplyUsageMrpAps.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SupplyUsageMrpAps
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SupplyUsageMrpApsSp(string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string Source = null,
		int? DisplayHeader = null,
		int? ALTNO = null,
		string pSite = null);
	}
}

