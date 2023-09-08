//PROJECT NAME: Reporting
//CLASS NAME: ISSSRMXRpt_VendorToBeShipped.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSRMXRpt_VendorToBeShipped
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_VendorToBeShippedSp(string StartVendNum = null,
		string EndVendNum = null,
		string StartItem = null,
		string EndItem = null,
		string StartRefNum = null,
		string EndRefNum = null,
		int? InclPO = 1,
		int? InclRMA = 1,
		string pSite = null);
	}
}

