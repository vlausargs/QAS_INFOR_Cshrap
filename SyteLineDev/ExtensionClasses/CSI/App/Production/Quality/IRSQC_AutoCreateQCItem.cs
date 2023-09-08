//PROJECT NAME: Production
//CLASS NAME: IRSQC_AutoCreateQCItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_AutoCreateQCItem
	{
		(int? ReturnCode, string o_messages,
		string Infobar) RSQC_AutoCreateQCItemSp(string i_item,
		string i_ref_type,
		string i_vend_num,
		string i_job,
		int? i_suffix,
		int? i_oper_num,
		string o_messages,
		string Infobar);
	}
}

