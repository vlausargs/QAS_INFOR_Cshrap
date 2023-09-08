//PROJECT NAME: PmfExt
//CLASS NAME: PmfFormulaLinesBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfFormulaLinesBase")]
	public class PmfFormulaLinesBase : CSIExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmGetItemsForLine()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmGetItemsForLineExt = new PmfFmGetItemsForLineFactory().Create(appDb);
				
				var result = iPmfFmGetItemsForLineExt.PmfFmGetItemsForLineSp();
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmLineValidateUi([Optional] ref string Infobar,
		                               [Optional] Guid? fm_rp,
		                               [Optional] Guid? rp,
		                               [Optional] ref int? seq,
		                               [Optional] ref int? fm_line_type,
		                               [Optional] ref string item,
		                               [Optional] string whse,
		                               [Optional] ref string bp,
		                               [Optional] ref decimal? qty,
		                               [Optional] ref decimal? gross_wt,
		                               [Optional] ref decimal? gross_vol,
		                               [Optional] ref decimal? gross_vol_wo_solubility,
		                               [Optional] ref decimal? net_wt,
		                               [Optional] ref decimal? net_vol,
		                               [Optional] ref decimal? cnv_to_stock,
		                               [Optional] ref decimal? loss_pct,
		                               [Optional] ref decimal? loss_const,
		                               [Optional] ref string um,
		                               [Optional] ref string stock_um,
		                               [Optional] ref decimal? stock_cnv_to_wt,
		                               [Optional] ref decimal? stock_cnv_to_vol,
		                               [Optional] ref int? disregard_wtvol,
		                               [Optional] ref decimal? solubility,
		                               [Optional] ref int? is_pct_basis,
		                               [Optional] ref string text_long)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmLineValidateUiExt = new PmfFmLineValidateUiFactory().Create(appDb);
				
				var result = iPmfFmLineValidateUiExt.PmfFmLineValidateUiSp(Infobar,
				                                                           fm_rp,
				                                                           rp,
				                                                           seq,
				                                                           fm_line_type,
				                                                           item,
				                                                           whse,
				                                                           bp,
				                                                           qty,
				                                                           gross_wt,
				                                                           gross_vol,
				                                                           gross_vol_wo_solubility,
				                                                           net_wt,
				                                                           net_vol,
				                                                           cnv_to_stock,
				                                                           loss_pct,
				                                                           loss_const,
				                                                           um,
				                                                           stock_um,
				                                                           stock_cnv_to_wt,
				                                                           stock_cnv_to_vol,
				                                                           disregard_wtvol,
				                                                           solubility,
				                                                           is_pct_basis,
				                                                           text_long);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				seq = result.seq;
				fm_line_type = result.fm_line_type;
				item = result.item;
				bp = result.bp;
				qty = result.qty;
				gross_wt = result.gross_wt;
				gross_vol = result.gross_vol;
				gross_vol_wo_solubility = result.gross_vol_wo_solubility;
				net_wt = result.net_wt;
				net_vol = result.net_vol;
				cnv_to_stock = result.cnv_to_stock;
				loss_pct = result.loss_pct;
				loss_const = result.loss_const;
				um = result.um;
				stock_um = result.stock_um;
				stock_cnv_to_wt = result.stock_cnv_to_wt;
				stock_cnv_to_vol = result.stock_cnv_to_vol;
				disregard_wtvol = result.disregard_wtvol;
				solubility = result.solubility;
				is_pct_basis = result.is_pct_basis;
				text_long = result.text_long;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfGetSubFmDetailV2()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfGetSubFmDetailV2Ext = new PmfGetSubFmDetailV2Factory().Create(appDb);
				
				var result = iPmfGetSubFmDetailV2Ext.PmfGetSubFmDetailV2Sp();
				
				
				return result.Value;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PmfFmGetOperationsSp(Guid? fm_rp)
		{
			var iPmfFmGetOperationsExt = new PmfFmGetOperationsFactory().Create(this, true);
			
			var result = iPmfFmGetOperationsExt.PmfFmGetOperationsSp(fm_rp);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

	}
}
