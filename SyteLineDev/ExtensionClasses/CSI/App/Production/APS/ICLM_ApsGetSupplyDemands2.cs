//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSupplyDemands2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetSupplyDemands2
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSupplyDemands2Sp(
			string SupplyType,
			string SupplyID);
	}
}

