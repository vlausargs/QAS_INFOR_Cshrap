//PROJECT NAME: Production
//CLASS NAME: IRSQC_ShipUpdateCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ShipUpdateCOC
	{
		(int? ReturnCode, string Infobar) RSQC_ShipUpdateCOCSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Infobar);
	}
}

