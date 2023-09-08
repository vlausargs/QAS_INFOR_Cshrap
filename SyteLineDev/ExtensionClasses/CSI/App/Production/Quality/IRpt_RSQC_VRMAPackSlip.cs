//PROJECT NAME: Production
//CLASS NAME: IRpt_RSQC_VRMAPackSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRpt_RSQC_VRMAPackSlip
	{
		int? Rpt_RSQC_VRMAPackSlipSp(int? Vrma = null,
		decimal? Qty = null,
		int? PrintInternal = null,
		int? PrintExternal = null);
	}
}

