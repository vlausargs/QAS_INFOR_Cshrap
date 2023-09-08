//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateTestXRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateTestXRef
	{
		(int? ReturnCode, string Infobar) RSQC_CreateTestXRefSp(int? i_rcvr,
		DateTime? i_trans_date,
		int? i_sequence,
		string i_doc_num,
		string i_type,
		string Infobar);
	}
}

