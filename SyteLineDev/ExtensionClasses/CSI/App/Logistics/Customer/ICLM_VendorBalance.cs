//PROJECT NAME: Logistics
//CLASS NAME: ICLM_VendorBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_VendorBalance
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_VendorBalanceSp(
			string FilterString = null,
			string SiteRef = null);
	}
}

