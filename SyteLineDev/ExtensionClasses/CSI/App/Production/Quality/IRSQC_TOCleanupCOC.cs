//PROJECT NAME: Production
//CLASS NAME: IRSQC_TOCleanupCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_TOCleanupCOC
	{
		(int? ReturnCode,
			string Infobar) RSQC_TOCleanupCOCSp(
			string Infobar);
	}
}

