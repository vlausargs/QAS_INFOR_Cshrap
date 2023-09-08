//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GenerateIntranetSites.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_GenerateIntranetSites
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateIntranetSitesSp(string SiteFilter = null);
	}
}

