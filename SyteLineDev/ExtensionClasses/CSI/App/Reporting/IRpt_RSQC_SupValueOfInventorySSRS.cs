//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupValueOfInventorySSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupValueOfInventorySSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupValueOfInventorySSRSSp(int? displayheader = null,
		string psite = null);
	}
}

