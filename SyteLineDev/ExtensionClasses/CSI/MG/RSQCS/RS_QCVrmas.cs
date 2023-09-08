//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCVrmas.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCVrmas")]
	public class RS_QCVrmas : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int Rpt_RSQC_VRMAPackSlipSp([Optional] int? Vrma,
		[Optional] decimal? Qty,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRpt_RSQC_VRMAPackSlipExt = new Rpt_RSQC_VRMAPackSlipFactory().Create(appDb);
				
				var result = iRpt_RSQC_VRMAPackSlipExt.Rpt_RSQC_VRMAPackSlipSp(Vrma,
				Qty,
				PrintInternal,
				PrintExternal);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetIssueValuesSp(ref string o_acct,
		ref string o_account_unit1,
		ref string o_account_unit2,
		ref string o_account_unit3,
		ref string o_account_unit4,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetIssueValuesExt = new RSQC_GetIssueValuesFactory().Create(appDb);
				
				var result = iRSQC_GetIssueValuesExt.RSQC_GetIssueValuesSp(o_acct,
				o_account_unit1,
				o_account_unit2,
				o_account_unit3,
				o_account_unit4,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_acct = result.o_acct;
				o_account_unit1 = result.o_account_unit1;
				o_account_unit2 = result.o_account_unit2;
				o_account_unit3 = result.o_account_unit3;
				o_account_unit4 = result.o_account_unit4;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetItemDataSp(string i_item,
		ref string o_UM,
		ref string o_revision,
		ref string o_drawing_nbr,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetItemDataExt = new RSQC_GetItemDataFactory().Create(appDb);
				
				var result = iRSQC_GetItemDataExt.RSQC_GetItemDataSp(i_item,
				o_UM,
				o_revision,
				o_drawing_nbr,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_UM = result.o_UM;
				o_revision = result.o_revision;
				o_drawing_nbr = result.o_drawing_nbr;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetPoItemDataSp(int? i_rcvr,
		string i_po_num,
		int? i_po_line,
		int? i_po_release,
		ref decimal? o_item_cost,
		ref decimal? o_plan_cost,
		ref decimal? o_unit_mat_cost,
		ref decimal? o_item_cost_conv,
		ref decimal? o_plan_cost_conv,
		ref decimal? o_unit_mat_cost_conv,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetPoItemDataExt = new RSQC_GetPoItemDataFactory().Create(appDb);
				
				var result = iRSQC_GetPoItemDataExt.RSQC_GetPoItemDataSp(i_rcvr,
				i_po_num,
				i_po_line,
				i_po_release,
				o_item_cost,
				o_plan_cost,
				o_unit_mat_cost,
				o_item_cost_conv,
				o_plan_cost_conv,
				o_unit_mat_cost_conv,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_item_cost = result.o_item_cost;
				o_plan_cost = result.o_plan_cost;
				o_unit_mat_cost = result.o_unit_mat_cost;
				o_item_cost_conv = result.o_item_cost_conv;
				o_plan_cost_conv = result.o_plan_cost_conv;
				o_unit_mat_cost_conv = result.o_unit_mat_cost_conv;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetRcvrLocLotSp(int? i_vrma,
		ref string o_lot,
		ref string o_loc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetRcvrLocLotExt = new RSQC_GetRcvrLocLotFactory().Create(appDb);
				
				var result = iRSQC_GetRcvrLocLotExt.RSQC_GetRcvrLocLotSp(i_vrma,
				o_lot,
				o_loc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_lot = result.o_lot;
				o_loc = result.o_loc;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetReceiptValuesSp(string i_item,
		string i_whse,
		string i_loc,
		ref decimal? o_unit_cost,
		ref decimal? o_matl_cost,
		ref decimal? o_qty_on_hand,
		ref string o_acct,
		ref string o_account_unit1,
		ref string o_account_unit2,
		ref string o_account_unit3,
		ref string o_account_unit4,
		ref int? o_SerialTracked,
		ref int? o_LotTracked,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetReceiptValuesExt = new RSQC_GetReceiptValuesFactory().Create(appDb);
				
				var result = iRSQC_GetReceiptValuesExt.RSQC_GetReceiptValuesSp(i_item,
				i_whse,
				i_loc,
				o_unit_cost,
				o_matl_cost,
				o_qty_on_hand,
				o_acct,
				o_account_unit1,
				o_account_unit2,
				o_account_unit3,
				o_account_unit4,
				o_SerialTracked,
				o_LotTracked,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_unit_cost = result.o_unit_cost;
				o_matl_cost = result.o_matl_cost;
				o_qty_on_hand = result.o_qty_on_hand;
				o_acct = result.o_acct;
				o_account_unit1 = result.o_account_unit1;
				o_account_unit2 = result.o_account_unit2;
				o_account_unit3 = result.o_account_unit3;
				o_account_unit4 = result.o_account_unit4;
				o_SerialTracked = result.o_SerialTracked;
				o_LotTracked = result.o_LotTracked;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetVoucherXRefSp(int? i_vrma,
		ref int? o_voucher,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetVoucherXRefExt = new RSQC_GetVoucherXRefFactory().Create(appDb);
				
				var result = iRSQC_GetVoucherXRefExt.RSQC_GetVoucherXRefSp(i_vrma,
				o_voucher,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_voucher = result.o_voucher;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetVrmaParmSp(ref string o_vrma_auto_rcpt,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetVrmaParmExt = new RSQC_GetVrmaParmFactory().Create(appDb);
				
				var result = iRSQC_GetVrmaParmExt.RSQC_GetVrmaParmSp(o_vrma_auto_rcpt,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_vrma_auto_rcpt = result.o_vrma_auto_rcpt;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SetUnitCostSp(int? i_vrma,
		ref decimal? o_unit_cost,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SetUnitCostExt = new RSQC_SetUnitCostFactory().Create(appDb);
				
				var result = iRSQC_SetUnitCostExt.RSQC_SetUnitCostSp(i_vrma,
				o_unit_cost,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_unit_cost = result.o_unit_cost;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_SetVrmaValuesSp(int? i_vrma,
		string i_type,
		decimal? i_qty,
		[Optional, DefaultParameterValue(0)] int? qcscrapadjust,
		[Optional, DefaultParameterValue(0)] int? qcreturnadjust,
		[Optional, DefaultParameterValue(0)] int? qcreceiveadjust,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_SetVrmaValuesExt = new RSQC_SetVrmaValuesFactory().Create(appDb);
				
				var result = iRSQC_SetVrmaValuesExt.RSQC_SetVrmaValuesSp(i_vrma,
				i_type,
				i_qty,
				qcscrapadjust,
				qcreturnadjust,
				qcreceiveadjust,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_XRefOrigPOSp(int? i_rcvr,
		ref string o_ref_num,
		ref int? o_ref_line,
		ref int? o_ref_rel,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_XRefOrigPOExt = new RSQC_XRefOrigPOFactory().Create(appDb);
				
				var result = iRSQC_XRefOrigPOExt.RSQC_XRefOrigPOSp(i_rcvr,
				o_ref_num,
				o_ref_line,
				o_ref_rel,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_ref_num = result.o_ref_num;
				o_ref_line = result.o_ref_line;
				o_ref_rel = result.o_ref_rel;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_XRefPOSp(string i_item,
		string i_vend_num_orig,
		decimal? i_qty_expected,
		string i_cur_whse,
		string i_ship_code,
		string i_ref_num,
		ref string o_ref_num,
		ref int? o_ref_line,
		ref int? o_ref_rel,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_XRefPOExt = new RSQC_XRefPOFactory().Create(appDb);
				
				var result = iRSQC_XRefPOExt.RSQC_XRefPOSp(i_item,
				i_vend_num_orig,
				i_qty_expected,
				i_cur_whse,
				i_ship_code,
				i_ref_num,
				o_ref_num,
				o_ref_line,
				o_ref_rel,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_ref_num = result.o_ref_num;
				o_ref_line = result.o_ref_line;
				o_ref_rel = result.o_ref_rel;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_XRefVoucherSp(int? i_vrma,
		string i_vend_num_orig,
		DateTime? i_dist_date,
		DateTime? i_inv_date,
		decimal? i_purch_amt,
		decimal? i_misc_charges,
		decimal? i_freight,
		decimal? i_inv_amt,
		decimal? i_vrma_pend,
		ref int? o_voucher,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_XRefVoucherExt = new RSQC_XRefVoucherFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_XRefVoucherExt.RSQC_XRefVoucherSp(i_vrma,
				i_vend_num_orig,
				i_dist_date,
				i_inv_date,
				i_purch_amt,
				i_misc_charges,
				i_freight,
				i_inv_amt,
				i_vrma_pend,
				o_voucher,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_voucher = result.o_voucher;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
