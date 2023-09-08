//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupVendorStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupVendorStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupVendorStatusSp(
			string begvend = null,
			string endvend = null,
			int? displayheader = null,
			int? PrintInternal = null,
			int? PrintExternal = null);
	}
}

