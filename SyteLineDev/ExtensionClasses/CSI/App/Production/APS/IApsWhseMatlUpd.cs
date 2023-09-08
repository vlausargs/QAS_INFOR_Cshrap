//PROJECT NAME: Production
//CLASS NAME: IApsWhseMatlUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsWhseMatlUpd
	{
		int? ApsWhseMatlUpdSp(string MATERIALID,
		string WHSE,
		int? FLAGS,
		decimal? QUONHAND,
		decimal? SAFETYSTOCK,
		int? SRCPRIORITY,
		string SRCCUSTOMER,
		string SRCWORKCENTER,
		Guid? RowP,
		int? AltNo);
	}
}

