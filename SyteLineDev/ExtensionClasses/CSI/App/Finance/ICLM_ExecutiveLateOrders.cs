//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveLateOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveLateOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveLateOrdersSp(string SiteGroup,
		DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString = null);
	}
}

