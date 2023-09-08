//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCOsmobi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCOsmobi
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCOsmobiSp(string CustNum,
		string SiteRef,
		string FilterString = null);
	}
}

