//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetDemandId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetDemandId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetDemandIdSp(string PDemandType,
		int? AltNo,
		string DemandIdFilter = null);
	}
}

