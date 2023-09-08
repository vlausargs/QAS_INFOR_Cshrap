//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSupplyID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetSupplyID
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSupplyIDSp(string SupplyType,
		string SupplyIdFilter = null);
	}
}

