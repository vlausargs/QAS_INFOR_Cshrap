//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetProspectEstimatesmobi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetProspectEstimatesmobi
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetProspectEstimatesmobiSp(string ProspectID);
	}
}

