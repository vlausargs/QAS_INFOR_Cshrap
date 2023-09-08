//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveOppWonLost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveOppWonLost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveOppWonLostSp(DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString = null);
	}
}

