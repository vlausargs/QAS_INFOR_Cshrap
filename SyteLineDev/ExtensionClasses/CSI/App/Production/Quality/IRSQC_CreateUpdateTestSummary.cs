//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateUpdateTestSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateUpdateTestSummary
	{
		(int? ReturnCode, string Infobar) RSQC_CreateUpdateTestSummarySp(int? i_rcvr,
		DateTime? i_trans_date,
		string Infobar);
	}
}

