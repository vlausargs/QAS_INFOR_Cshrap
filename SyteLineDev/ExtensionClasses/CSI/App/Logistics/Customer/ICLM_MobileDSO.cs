//PROJECT NAME: Logistics
//CLASS NAME: ICLM_MobileDSO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_MobileDSO
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_MobileDSOSp(string SiteRef = null);
	}
}

