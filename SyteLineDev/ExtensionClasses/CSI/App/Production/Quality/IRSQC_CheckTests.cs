//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckTests
	{
		(int? ReturnCode, string Infobar) RSQC_CheckTestsSp(string i_item,
		string i_ref_type,
		string i_entity,
		string i_test_type,
		int? i_test_seq,
		string Infobar);
	}
}

