//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceGroupBottlenecksAps.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ResourceGroupBottlenecksAps
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupBottlenecksApsSp(string GroupStarting,
		string GroupEnding,
		DateTime? StartDate,
		DateTime? EndDate,
		int? ExcludeInfinite,
		int? ListDelays,
		int? DisplayHeader,
		int? ALTNO,
		string pSite = null);
	}
}

