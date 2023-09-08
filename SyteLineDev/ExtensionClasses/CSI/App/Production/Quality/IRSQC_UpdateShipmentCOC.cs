//PROJECT NAME: Production
//CLASS NAME: IRSQC_UpdateShipmentCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_UpdateShipmentCOC
	{
		(int? ReturnCode, string Infobar) RSQC_UpdateShipmentCOCSp(decimal? ShipmentId,
		int? ShipmentLine,
		decimal? Qty,
		string Infobar);
	}
}

