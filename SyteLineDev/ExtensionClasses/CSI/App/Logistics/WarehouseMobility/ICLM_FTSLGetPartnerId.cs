//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetPartnerId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetPartnerId
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string PartnerID) CLM_FTSLGetPartnerIdSp(string EmployeeNumber,
		string PartnerID);
	}
}

