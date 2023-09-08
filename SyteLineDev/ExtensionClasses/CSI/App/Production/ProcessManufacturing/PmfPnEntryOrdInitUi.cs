//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryOrdInitUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnEntryOrdInitUi
	{
		(int? ReturnCode, string Infobar, int? seq, string item, string whse, decimal? qty_ord, string ord_um, int? bom_item_source, string bom_item_ovrd, decimal? cost_absorption_pct, decimal? fill_wt, decimal? fill_vol) PmfPnEntryOrdInitUiSp(string Infobar = null,
		                                                                                                                                                                                                                                            Guid? pn_wrk_rp = null,
		                                                                                                                                                                                                                                            Guid? rp = null,
		                                                                                                                                                                                                                                            int? seq = null,
		                                                                                                                                                                                                                                            string item = null,
		                                                                                                                                                                                                                                            string whse = null,
		                                                                                                                                                                                                                                            decimal? qty_ord = null,
		                                                                                                                                                                                                                                            string ord_um = null,
		                                                                                                                                                                                                                                            int? bom_item_source = null,
		                                                                                                                                                                                                                                            string bom_item_ovrd = null,
		                                                                                                                                                                                                                                            decimal? cost_absorption_pct = null,
		                                                                                                                                                                                                                                            decimal? fill_wt = null,
		                                                                                                                                                                                                                                            decimal? fill_vol = null);
	}
	
	public class PmfPnEntryOrdInitUi : IPmfPnEntryOrdInitUi
	{
		readonly IApplicationDB appDB;
		
		public PmfPnEntryOrdInitUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, int? seq, string item, string whse, decimal? qty_ord, string ord_um, int? bom_item_source, string bom_item_ovrd, decimal? cost_absorption_pct, decimal? fill_wt, decimal? fill_vol) PmfPnEntryOrdInitUiSp(string Infobar = null,
		                                                                                                                                                                                                                                                   Guid? pn_wrk_rp = null,
		                                                                                                                                                                                                                                                   Guid? rp = null,
		                                                                                                                                                                                                                                                   int? seq = null,
		                                                                                                                                                                                                                                                   string item = null,
		                                                                                                                                                                                                                                                   string whse = null,
		                                                                                                                                                                                                                                                   decimal? qty_ord = null,
		                                                                                                                                                                                                                                                   string ord_um = null,
		                                                                                                                                                                                                                                                   int? bom_item_source = null,
		                                                                                                                                                                                                                                                   string bom_item_ovrd = null,
		                                                                                                                                                                                                                                                   decimal? cost_absorption_pct = null,
		                                                                                                                                                                                                                                                   decimal? fill_wt = null,
		                                                                                                                                                                                                                                                   decimal? fill_vol = null)
		{
			InfobarType _Infobar = Infobar;
			RowPointerType _pn_wrk_rp = pn_wrk_rp;
			RowPointerType _rp = rp;
			IntType _seq = seq;
			ItemType _item = item;
			WhseType _whse = whse;
			ProcessMfgQuantityType _qty_ord = qty_ord;
			UMType _ord_um = ord_um;
			IntType _bom_item_source = bom_item_source;
			ItemType _bom_item_ovrd = bom_item_ovrd;
			ProcessMfgPercentType _cost_absorption_pct = cost_absorption_pct;
			ProcessMfgQuantityType _fill_wt = fill_wt;
			ProcessMfgQuantityType _fill_vol = fill_vol;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnEntryOrdInitUiSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pn_wrk_rp", _pn_wrk_rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rp", _rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "seq", _seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "whse", _whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "qty_ord", _qty_ord, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ord_um", _ord_um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "bom_item_source", _bom_item_source, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "bom_item_ovrd", _bom_item_ovrd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "cost_absorption_pct", _cost_absorption_pct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fill_wt", _fill_wt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fill_vol", _fill_vol, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				seq = _seq;
				item = _item;
				whse = _whse;
				qty_ord = _qty_ord;
				ord_um = _ord_um;
				bom_item_source = _bom_item_source;
				bom_item_ovrd = _bom_item_ovrd;
				cost_absorption_pct = _cost_absorption_pct;
				fill_wt = _fill_wt;
				fill_vol = _fill_vol;
				
				return (Severity, Infobar, seq, item, whse, qty_ord, ord_um, bom_item_source, bom_item_ovrd, cost_absorption_pct, fill_wt, fill_vol);
			}
		}
	}
}
