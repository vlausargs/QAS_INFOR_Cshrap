//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupReadyForInspSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupReadyForInspSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupReadyForInspSSRSSp(int? showdetail = null,
		int? openreconly = null,
		int? displayheader = null,
		string psite = null);
	}
}

