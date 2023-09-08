//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateBatchTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateBatchTests
	{
		(int? ReturnCode, string o_message,
		string Infobar) RSQC_CreateBatchTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		string o_message,
		string Infobar);
	}
}

