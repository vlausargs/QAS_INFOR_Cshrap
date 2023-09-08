//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveWCEarnedAmounts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveWCEarnedAmounts
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveWCEarnedAmountsSp(DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString);
	}
}

