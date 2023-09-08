//PROJECT NAME: Production
//CLASS NAME: IRSQC_TOUpdateCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_TOUpdateCOC
	{
		(int? ReturnCode,
			string Infobar) RSQC_TOUpdateCOCSp(
			string ToNum,
			int? ToLine,
			int? ToRelease,
			string Infobar);
	}
}

