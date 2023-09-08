//PROJECT NAME: PmfExt
//CLASS NAME: PmfMfgSpecOrdersBase.cs

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
	[IDOExtensionClass("PmfMfgSpecOrdersBase")]
	public class PmfMfgSpecOrdersBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfSpecOrdInitUi([Optional] ref string Infobar,
		                            [Optional] Guid? mf_spec_rp,
		                            [Optional] Guid? rp,
		                            [Optional] int? seq,
		                            [Optional] Guid? fm_rp,
		                            [Optional] ref string item,
		                            [Optional] ref string whse,
		                            [Optional] ref decimal? std_ord_qty,
		                            [Optional] ref string std_ord_um,
		                            [Optional] ref int? bom_source,
		                            [Optional] ref string bom_item_ovrd,
		                            [Optional] ref decimal? cost_absorption_pct,
		                            [Optional] ref decimal? base_wt_ord,
		                            [Optional] ref decimal? base_vol_ord)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfSpecOrdInitUiExt = new PmfSpecOrdInitUiFactory().Create(appDb);
				
				var result = iPmfSpecOrdInitUiExt.PmfSpecOrdInitUiSp(Infobar,
				                                                     mf_spec_rp,
				                                                     rp,
				                                                     seq,
				                                                     fm_rp,
				                                                     item,
				                                                     whse,
				                                                     std_ord_qty,
				                                                     std_ord_um,
				                                                     bom_source,
				                                                     bom_item_ovrd,
				                                                     cost_absorption_pct,
				                                                     base_wt_ord,
				                                                     base_vol_ord);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				item = result.item;
				whse = result.whse;
				std_ord_qty = result.std_ord_qty;
				std_ord_um = result.std_ord_um;
				bom_source = result.bom_source;
				bom_item_ovrd = result.bom_item_ovrd;
				cost_absorption_pct = result.cost_absorption_pct;
				base_wt_ord = result.base_wt_ord;
				base_vol_ord = result.base_vol_ord;
				return Severity;
			}
		}
	}
}
