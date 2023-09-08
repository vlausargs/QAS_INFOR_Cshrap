//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetEstimatesmobi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetEstimatesmobi
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetEstimatesmobiSp(string Customer,
		string SiteRef,
		string Filter = null);
	}
}

