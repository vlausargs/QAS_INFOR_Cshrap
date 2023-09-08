//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSupplyDemands.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetSupplyDemands
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSupplyDemandsSp(string SupplyType,
		string Item,
		int? SupplyMatltag,
		int? ShowTopOnly,
		int? AltNo,
		string FilterString);
	}
}

