//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateSerialTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateSerialTests
	{
		(int? ReturnCode, string Infobar) RSQC_CreateSerialTestsSp(int? i_rcvr,
		DateTime? i_trans_date,
		string i_ref_type,
		string i_item,
		int? i_oper_num,
		string i_entity,
		string i_ref_num,
		int? i_ref_line,
		int? i_ref_release,
		string i_test_type,
		int? i_test_seq,
		string Infobar);
	}
}

