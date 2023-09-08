//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_VRMAPackSlipSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_VRMAPackSlipSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_VRMAPackSlipSSRSSp(int? Vrma = null,
		decimal? Qty = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

