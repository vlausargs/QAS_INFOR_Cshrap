//PROJECT NAME: Production
//CLASS NAME: IRSQC_CopyTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CopyTests
	{
		(int? ReturnCode, string Infobar) RSQC_CopyTestsSp(string i_item,
		string i_ref_type,
		string i_entity,
		string i_test_type = null,
		int? i_test_seq = null,
		string i_item2 = null,
		string i_ref_type2 = null,
		string i_entity2 = null,
		string i_test_type2 = null,
		int? i_test_seq2 = null,
		string i_item3 = null,
		string i_ref_type3 = null,
		string i_entity3 = null,
		string i_test_type3 = null,
		int? i_test_seq3 = null,
		string Infobar = null);
	}
}

