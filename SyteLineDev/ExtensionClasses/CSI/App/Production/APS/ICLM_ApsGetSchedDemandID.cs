//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSchedDemandID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetSchedDemandID
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSchedDemandIDSp(string PDemandType,
		string PDemandId);
	}
}

