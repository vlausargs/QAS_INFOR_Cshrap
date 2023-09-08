//PROJECT NAME: Production
//CLASS NAME: IRSQC_ShipCleanupCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ShipCleanupCOC
	{
		(int? ReturnCode, string Infobar) RSQC_ShipCleanupCOCSp(string Infobar);
	}
}

