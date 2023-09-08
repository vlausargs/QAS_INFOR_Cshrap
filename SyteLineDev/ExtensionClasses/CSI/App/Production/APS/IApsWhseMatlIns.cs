//PROJECT NAME: Production
//CLASS NAME: IApsWhseMatlIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsWhseMatlIns
	{
		int? ApsWhseMatlInsSp(string MATERIALID,
		string WHSE,
		int? FLAGS,
		decimal? QUONHAND,
		decimal? SAFETYSTOCK,
		int? SRCPRIORITY,
		string SRCCUSTOMER,
		string SRCWORKCENTER,
		int? AltNo);
	}
}

