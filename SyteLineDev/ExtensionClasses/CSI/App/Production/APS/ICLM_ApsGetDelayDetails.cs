//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetDelayDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetDelayDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetDelayDetailsSp(int? AltNo,
		int? WaitMatltag,
		string WaitJsid,
		string WaitType,
		string WaitID,
		DateTime? EarliestStart,
		DateTime? ActualEnd,
		string SubFilterString = null);
	}
}

