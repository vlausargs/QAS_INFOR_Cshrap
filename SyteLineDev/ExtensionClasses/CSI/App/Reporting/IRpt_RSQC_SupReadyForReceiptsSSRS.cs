//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupReadyForReceiptsSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupReadyForReceiptsSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupReadyForReceiptsSSRSSp(int? showdetail = null,
		int? displayheader = null,
		string psite = null);
	}
}

