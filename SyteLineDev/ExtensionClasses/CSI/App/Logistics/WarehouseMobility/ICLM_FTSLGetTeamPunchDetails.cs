//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetTeamPunchDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetTeamPunchDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetTeamPunchDetailsSp(string ERPQueryResponseString);
	}
}

