//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckSerialTracked.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckSerialTracked
	{
		(int? ReturnCode, int? o_serial_tracked,
		string Infobar) RSQC_CheckSerialTrackedSp(string i_item,
		string i_ref_type,
		string i_vend_num,
		string i_job,
		int? i_suffix,
		int? i_oper_num,
		int? o_serial_tracked,
		string Infobar);
	}
}

