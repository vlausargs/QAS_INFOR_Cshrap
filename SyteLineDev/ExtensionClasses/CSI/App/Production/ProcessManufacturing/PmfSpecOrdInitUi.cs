//PROJECT NAME: Production
//CLASS NAME: PmfSpecOrdInitUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfSpecOrdInitUi
	{
		(int? ReturnCode, string Infobar, string item, string whse, decimal? std_ord_qty, string std_ord_um, int? bom_source, string bom_item_ovrd, decimal? cost_absorption_pct, decimal? base_wt_ord, decimal? base_vol_ord) PmfSpecOrdInitUiSp(string Infobar = null,
		                                                                                                                                                                                                                                          Guid? mf_spec_rp = null,
		                                                                                                                                                                                                                                          Guid? rp = null,
		                                                                                                                                                                                                                                          int? seq = null,
		                                                                                                                                                                                                                                          Guid? fm_rp = null,
		                                                                                                                                                                                                                                          string item = null,
		                                                                                                                                                                                                                                          string whse = null,
		                                                                                                                                                                                                                                          decimal? std_ord_qty = null,
		                                                                                                                                                                                                                                          string std_ord_um = null,
		                                                                                                                                                                                                                                          int? bom_source = null,
		                                                                                                                                                                                                                                          string bom_item_ovrd = null,
		                                                                                                                                                                                                                                          decimal? cost_absorption_pct = null,
		                                                                                                                                                                                                                                          decimal? base_wt_ord = null,
		                                                                                                                                                                                                                                          decimal? base_vol_ord = null);
	}
	
	public class PmfSpecOrdInitUi : IPmfSpecOrdInitUi
	{
		readonly IApplicationDB appDB;
		
		public PmfSpecOrdInitUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string item, string whse, decimal? std_ord_qty, string std_ord_um, int? bom_source, string bom_item_ovrd, decimal? cost_absorption_pct, decimal? base_wt_ord, decimal? base_vol_ord) PmfSpecOrdInitUiSp(string Infobar = null,
		                                                                                                                                                                                                                                                 Guid? mf_spec_rp = null,
		                                                                                                                                                                                                                                                 Guid? rp = null,
		                                                                                                                                                                                                                                                 int? seq = null,
		                                                                                                                                                                                                                                                 Guid? fm_rp = null,
		                                                                                                                                                                                                                                                 string item = null,
		                                                                                                                                                                                                                                                 string whse = null,
		                                                                                                                                                                                                                                                 decimal? std_ord_qty = null,
		                                                                                                                                                                                                                                                 string std_ord_um = null,
		                                                                                                                                                                                                                                                 int? bom_source = null,
		                                                                                                                                                                                                                                                 string bom_item_ovrd = null,
		                                                                                                                                                                                                                                                 decimal? cost_absorption_pct = null,
		                                                                                                                                                                                                                                                 decimal? base_wt_ord = null,
		                                                                                                                                                                                                                                                 decimal? base_vol_ord = null)
		{
			InfobarType _Infobar = Infobar;
			RowPointerType _mf_spec_rp = mf_spec_rp;
			RowPointerType _rp = rp;
			IntType _seq = seq;
			RowPointerType _fm_rp = fm_rp;
			ItemType _item = item;
			WhseType _whse = whse;
			ProcessMfgQuantityType _std_ord_qty = std_ord_qty;
			UMType _std_ord_um = std_ord_um;
			IntType _bom_source = bom_source;
			ItemType _bom_item_ovrd = bom_item_ovrd;
			ProcessMfgPercentType _cost_absorption_pct = cost_absorption_pct;
			ProcessMfgQuantityType _base_wt_ord = base_wt_ord;
			ProcessMfgQuantityType _base_vol_ord = base_vol_ord;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfSpecOrdInitUiSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "mf_spec_rp", _mf_spec_rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rp", _rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "seq", _seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "fm_rp", _fm_rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "whse", _whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "std_ord_qty", _std_ord_qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "std_ord_um", _std_ord_um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "bom_source", _bom_source, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "bom_item_ovrd", _bom_item_ovrd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "cost_absorption_pct", _cost_absorption_pct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "base_wt_ord", _base_wt_ord, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "base_vol_ord", _base_vol_ord, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				item = _item;
				whse = _whse;
				std_ord_qty = _std_ord_qty;
				std_ord_um = _std_ord_um;
				bom_source = _bom_source;
				bom_item_ovrd = _bom_item_ovrd;
				cost_absorption_pct = _cost_absorption_pct;
				base_wt_ord = _base_wt_ord;
				base_vol_ord = _base_vol_ord;
				
				return (Severity, Infobar, item, whse, std_ord_qty, std_ord_um, bom_source, bom_item_ovrd, cost_absorption_pct, base_wt_ord, base_vol_ord);
			}
		}
	}
}
