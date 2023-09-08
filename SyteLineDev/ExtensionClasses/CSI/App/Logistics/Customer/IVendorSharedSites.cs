//PROJECT NAME: Logistics
//CLASS NAME: IVendorSharedSites.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IVendorSharedSites
	{
		(ICollectionLoadResponse Data, int? ReturnCode) VendorSharedSitesSp(string SiteFilter = null);
	}
}

