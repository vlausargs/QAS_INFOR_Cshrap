//PROJECT NAME: Logistics
//CLASS NAME: IFTSLRSQC_UpdateCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLRSQC_UpdateCOC
	{
		(int? ReturnCode, string Infobar) FTSLRSQC_UpdateCOCSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		decimal? QtyCOC,
		string Infobar);
	}
}

