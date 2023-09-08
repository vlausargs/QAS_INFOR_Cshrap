//PROJECT NAME: Logistics
//CLASS NAME: ICLM_MobileDPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_MobileDPO
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_MobileDPOSp(string SiteRef);
	}
}

