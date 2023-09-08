//PROJECT NAME: Production
//CLASS NAME: IRSQC_XRefChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_XRefChange
	{
		(int? ReturnCode, int? o_change_num) RSQC_XRefChangeSp(string i_change,
		int? i_priority,
		int? o_change_num);
	}
}

