//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupValueOfInventory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupValueOfInventory
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupValueOfInventorySp(
			int? displayheader = null);
	}
}

