//PROJECT NAME: Production
//CLASS NAME: IRSQC_XRefOrigPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_XRefOrigPO
	{
		(int? ReturnCode, string o_ref_num,
		int? o_ref_line,
		int? o_ref_rel,
		string Infobar) RSQC_XRefOrigPOSp(int? i_rcvr,
		string o_ref_num,
		int? o_ref_line,
		int? o_ref_rel,
		string Infobar);
	}
}

