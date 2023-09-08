//PROJECT NAME: Production
//CLASS NAME: IApsWhseUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsWhseUpd
	{
		int? ApsWhseUpdSp(string WHSE,
		int? derPLANINTRASITETRANSFERS,
		decimal? TRNTIME,
		Guid? RowP,
		int? AltNo);
	}
}

