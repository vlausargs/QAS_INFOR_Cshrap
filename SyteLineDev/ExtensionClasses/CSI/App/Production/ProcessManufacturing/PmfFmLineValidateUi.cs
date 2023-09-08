//PROJECT NAME: Production
//CLASS NAME: PmfFmLineValidateUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmLineValidateUi
	{
		(int? ReturnCode, string Infobar, int? seq, int? fm_line_type, string item, string bp, decimal? qty, decimal? gross_wt, decimal? gross_vol, decimal? gross_vol_wo_solubility, decimal? net_wt, decimal? net_vol, decimal? cnv_to_stock, decimal? loss_pct, decimal? loss_const, string um, string stock_um, decimal? stock_cnv_to_wt, decimal? stock_cnv_to_vol, int? disregard_wtvol, decimal? solubility, int? is_pct_basis, string text_long) PmfFmLineValidateUiSp(string Infobar = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       Guid? fm_rp = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       Guid? rp = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       int? seq = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       int? fm_line_type = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       string item = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       string whse = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       string bp = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? qty = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? gross_wt = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? gross_vol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? gross_vol_wo_solubility = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? net_wt = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? net_vol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? cnv_to_stock = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? loss_pct = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? loss_const = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       string um = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       string stock_um = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? stock_cnv_to_wt = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? stock_cnv_to_vol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       int? disregard_wtvol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       decimal? solubility = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       int? is_pct_basis = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                       string text_long = null);
	}
	
	public class PmfFmLineValidateUi : IPmfFmLineValidateUi
	{
		readonly IApplicationDB appDB;
		
		public PmfFmLineValidateUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, int? seq, int? fm_line_type, string item, string bp, decimal? qty, decimal? gross_wt, decimal? gross_vol, decimal? gross_vol_wo_solubility, decimal? net_wt, decimal? net_vol, decimal? cnv_to_stock, decimal? loss_pct, decimal? loss_const, string um, string stock_um, decimal? stock_cnv_to_wt, decimal? stock_cnv_to_vol, int? disregard_wtvol, decimal? solubility, int? is_pct_basis, string text_long) PmfFmLineValidateUiSp(string Infobar = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              Guid? fm_rp = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              Guid? rp = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              int? seq = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              int? fm_line_type = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              string item = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              string whse = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              string bp = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? qty = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? gross_wt = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? gross_vol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? gross_vol_wo_solubility = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? net_wt = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? net_vol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? cnv_to_stock = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? loss_pct = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? loss_const = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              string um = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              string stock_um = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? stock_cnv_to_wt = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? stock_cnv_to_vol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              int? disregard_wtvol = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              decimal? solubility = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              int? is_pct_basis = null,
		                                                                                                                                                                                                                                                                                                                                                                                                                                                                              string text_long = null)
		{
			InfobarType _Infobar = Infobar;
			RowPointer _fm_rp = fm_rp;
			RowPointer _rp = rp;
			IntType _seq = seq;
			IntType _fm_line_type = fm_line_type;
			ItemType _item = item;
			WhseType _whse = whse;
			ProcessMfgBoilerplateTextCodeType _bp = bp;
			DecimalType _qty = qty;
			DecimalType _gross_wt = gross_wt;
			DecimalType _gross_vol = gross_vol;
			DecimalType _gross_vol_wo_solubility = gross_vol_wo_solubility;
			DecimalType _net_wt = net_wt;
			DecimalType _net_vol = net_vol;
			DecimalType _cnv_to_stock = cnv_to_stock;
			DecimalType _loss_pct = loss_pct;
			DecimalType _loss_const = loss_const;
			UMType _um = um;
			UMType _stock_um = stock_um;
			DecimalType _stock_cnv_to_wt = stock_cnv_to_wt;
			DecimalType _stock_cnv_to_vol = stock_cnv_to_vol;
			IntType _disregard_wtvol = disregard_wtvol;
			DecimalType _solubility = solubility;
			IntType _is_pct_basis = is_pct_basis;
			StringType _text_long = text_long;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmLineValidateUiSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fm_rp", _fm_rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rp", _rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "seq", _seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fm_line_type", _fm_line_type, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "whse", _whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bp", _bp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "qty", _qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "gross_wt", _gross_wt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "gross_vol", _gross_vol, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "gross_vol_wo_solubility", _gross_vol_wo_solubility, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "net_wt", _net_wt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "net_vol", _net_vol, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "cnv_to_stock", _cnv_to_stock, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "loss_pct", _loss_pct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "loss_const", _loss_const, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "um", _um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "stock_um", _stock_um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "stock_cnv_to_wt", _stock_cnv_to_wt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "stock_cnv_to_vol", _stock_cnv_to_vol, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "disregard_wtvol", _disregard_wtvol, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "solubility", _solubility, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "is_pct_basis", _is_pct_basis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "text_long", _text_long, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				seq = _seq;
				fm_line_type = _fm_line_type;
				item = _item;
				bp = _bp;
				qty = _qty;
				gross_wt = _gross_wt;
				gross_vol = _gross_vol;
				gross_vol_wo_solubility = _gross_vol_wo_solubility;
				net_wt = _net_wt;
				net_vol = _net_vol;
				cnv_to_stock = _cnv_to_stock;
				loss_pct = _loss_pct;
				loss_const = _loss_const;
				um = _um;
				stock_um = _stock_um;
				stock_cnv_to_wt = _stock_cnv_to_wt;
				stock_cnv_to_vol = _stock_cnv_to_vol;
				disregard_wtvol = _disregard_wtvol;
				solubility = _solubility;
				is_pct_basis = _is_pct_basis;
				text_long = _text_long;
				
				return (Severity, Infobar, seq, fm_line_type, item, bp, qty, gross_wt, gross_vol, gross_vol_wo_solubility, net_wt, net_vol, cnv_to_stock, loss_pct, loss_const, um, stock_um, stock_cnv_to_wt, stock_cnv_to_vol, disregard_wtvol, solubility, is_pct_basis, text_long);
			}
		}
	}
}
