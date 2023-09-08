//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetRcvrLocLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetRcvrLocLot
	{
		(int? ReturnCode, string o_lot,
		string o_loc,
		string Infobar) RSQC_GetRcvrLocLotSp(int? i_vrma,
		string o_lot,
		string o_loc,
		string Infobar);
	}
}

