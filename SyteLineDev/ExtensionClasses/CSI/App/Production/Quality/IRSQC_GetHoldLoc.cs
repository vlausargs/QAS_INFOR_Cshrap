//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetHoldLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetHoldLoc
	{
		(int? ReturnCode, string o_hold_loc,
		int? o_use_hold_loc) RSQC_GetHoldLocSp(string o_hold_loc,
		int? o_use_hold_loc);
	}
}

