//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveCashReceived.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveCashReceived
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveCashReceivedSp(string SiteGroup = null,
		DateTime? DateStarting = null,
		DateTime? DateEnding = null,
		string FilterString = null);
	}
}

