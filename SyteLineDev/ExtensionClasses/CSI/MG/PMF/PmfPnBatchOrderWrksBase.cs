//PROJECT NAME: PmfExt
//CLASS NAME: PmfPnBatchOrderWrksBase.cs

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
	[IDOExtensionClass("PmfPnBatchOrderWrksBase")]
	public class PmfPnBatchOrderWrksBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnEntryOrdInitUi([Optional] ref string Infobar,
		                               [Optional] Guid? pn_wrk_rp,
		                               [Optional] Guid? rp,
		                               [Optional] ref int? seq,
		                               [Optional] ref string item,
		                               [Optional] ref string whse,
		                               [Optional] ref decimal? qty_ord,
		                               [Optional] ref string ord_um,
		                               [Optional] ref int? bom_item_source,
		                               [Optional] ref string bom_item_ovrd,
		                               [Optional] ref decimal? cost_absorption_pct,
		                               [Optional] ref decimal? fill_wt,
		                               [Optional] ref decimal? fill_vol)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnEntryOrdInitUiExt = new PmfPnEntryOrdInitUiFactory().Create(appDb);
				
				var result = iPmfPnEntryOrdInitUiExt.PmfPnEntryOrdInitUiSp(Infobar,
				                                                           pn_wrk_rp,
				                                                           rp,
				                                                           seq,
				                                                           item,
				                                                           whse,
				                                                           qty_ord,
				                                                           ord_um,
				                                                           bom_item_source,
				                                                           bom_item_ovrd,
				                                                           cost_absorption_pct,
				                                                           fill_wt,
				                                                           fill_vol);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				seq = result.seq;
				item = result.item;
				whse = result.whse;
				qty_ord = result.qty_ord;
				ord_um = result.ord_um;
				bom_item_source = result.bom_item_source;
				bom_item_ovrd = result.bom_item_ovrd;
				cost_absorption_pct = result.cost_absorption_pct;
				fill_wt = result.fill_wt;
				fill_vol = result.fill_vol;
				return Severity;
			}
		}
	}
}
