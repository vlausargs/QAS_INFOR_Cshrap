//PROJECT NAME: Production
//CLASS NAME: IApsWhseIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsWhseIns
	{
		int? ApsWhseInsSp(string WHSE,
		int? derPLANINTRASITETRANSFERS,
		decimal? TRNTIME,
		int? AltNo);
	}
}

