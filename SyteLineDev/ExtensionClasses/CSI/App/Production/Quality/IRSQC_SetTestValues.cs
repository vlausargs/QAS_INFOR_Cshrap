//PROJECT NAME: Production
//CLASS NAME: IRSQC_SetTestValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SetTestValues
	{
		(int? ReturnCode, int? o_seq,
		string Infobar) RSQC_SetTestValuesSp(string i_item,
		string i_ref_type,
		string i_entity,
		int? i_testseq,
		int? o_seq,
		string Infobar);
	}
}

