//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetVrmaParm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetVrmaParm
	{
		(int? ReturnCode, string o_vrma_auto_rcpt,
		string Infobar) RSQC_GetVrmaParmSp(string o_vrma_auto_rcpt,
		string Infobar);
	}
}

