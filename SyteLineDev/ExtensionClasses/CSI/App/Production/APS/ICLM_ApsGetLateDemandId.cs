//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetLateDemandId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetLateDemandId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetLateDemandIdSp(string PDemandType);
	}
}

