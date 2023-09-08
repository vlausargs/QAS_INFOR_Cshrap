//PROJECT NAME: Data
//CLASS NAME: CalCCQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalCCQty : ICalCCQty
	{
		readonly IApplicationDB appDB;
		
		public CalCCQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			decimal? tc_qtu_cycle_qty_rsvd)
		{
			SerNumType _ser_num = ser_num;
			WhseType _whse = whse;
			ItemType _item = item;
			LocType _loc = loc;
			LotType _lot = lot;
			QtyUnitType _itemloc_qty_on_hand = itemloc_qty_on_hand;
			QtyUnitType _itemloc_qty_rsvd = itemloc_qty_rsvd;
			QtyUnitType _tc_qtu_cycle_qty_on_hand = tc_qtu_cycle_qty_on_hand;
			QtyUnitType _tc_qtu_cycle_qty_rsvd = tc_qtu_cycle_qty_rsvd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalCCQtySp";
				
				appDB.AddCommandParameter(cmd, "ser_num", _ser_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "whse", _whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "loc", _loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lot", _lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "itemloc_qty_on_hand", _itemloc_qty_on_hand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "itemloc_qty_rsvd", _itemloc_qty_rsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tc_qtu_cycle_qty_on_hand", _tc_qtu_cycle_qty_on_hand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "tc_qtu_cycle_qty_rsvd", _tc_qtu_cycle_qty_rsvd, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				tc_qtu_cycle_qty_on_hand = _tc_qtu_cycle_qty_on_hand;
				tc_qtu_cycle_qty_rsvd = _tc_qtu_cycle_qty_rsvd;
				
				return (Severity, tc_qtu_cycle_qty_on_hand, tc_qtu_cycle_qty_rsvd);
			}
		}
	}
}
