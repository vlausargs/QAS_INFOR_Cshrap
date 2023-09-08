//PROJECT NAME: Data
//CLASS NAME: ICalCCQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalCCQty
	{
		(int? ReturnCode,
			decimal? tc_qtu_cycle_qty_on_hand,
			decimal? tc_qtu_cycle_qty_rsvd) CalCCQtySp(
			string ser_num,
			string whse,
			string item,
			string loc,
			string lot,
			decimal? itemloc_qty_on_hand,
			decimal? itemloc_qty_rsvd,
			decimal? tc_qtu_cycle_qty_on_hand,
			decimal? tc_qtu_cycle_qty_rsvd);
	}
}

