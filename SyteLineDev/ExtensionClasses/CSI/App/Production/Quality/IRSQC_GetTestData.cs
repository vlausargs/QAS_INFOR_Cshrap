//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetTestData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetTestData
	{
		(int? ReturnCode, string o_each,
		string o_batch,
		string o_summary,
		string o_fail,
		string Infobar) RSQC_GetTestDataSp(int? i_rcvr,
		DateTime? i_trans_date,
		string o_each,
		string o_batch,
		string o_summary,
		string o_fail,
		string Infobar);
	}
}

