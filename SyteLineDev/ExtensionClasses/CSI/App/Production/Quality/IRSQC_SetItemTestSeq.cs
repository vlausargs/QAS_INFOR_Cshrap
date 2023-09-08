//PROJECT NAME: Production
//CLASS NAME: IRSQC_SetItemTestSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SetItemTestSeq
	{
		(int? ReturnCode, int? o_testseq,
		string Infobar) RSQC_SetItemTestSeqSp(string i_item,
		string i_ref_type,
		string i_entity,
		int? o_testseq,
		string Infobar);
	}
}

