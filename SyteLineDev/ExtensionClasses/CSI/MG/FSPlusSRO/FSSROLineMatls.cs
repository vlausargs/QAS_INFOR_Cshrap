//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROLineMatls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSSROLineMatls")]
    public class FSSROLineMatls : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROLineTransValidQtySp(string SRONum,
                                               int? SROLine,
                                               decimal? QtyConv,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROLineTransValidQtyExt = new SSSFSSROLineTransValidQtyFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSSSFSSROLineTransValidQtyExt.SSSFSSROLineTransValidQtySp(SRONum,
                                                                                         SROLine,
                                                                                         QtyConv,
                                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetDefWhseSp(string Table,
		                             string IRefType,
		                             string IRefNum,
		                             int? IRefLine,
		                             int? IRefRel,
		                             string IPartnerId,
		                             ref string OWhse,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetDefWhseExt = new SSSFSGetDefWhseFactory().Create(appDb);
				
				int Severity = iSSSFSGetDefWhseExt.SSSFSGetDefWhseSp(Table,
				                                                     IRefType,
				                                                     IRefNum,
				                                                     IRefLine,
				                                                     IRefRel,
				                                                     IPartnerId,
				                                                     ref OWhse,
				                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransWipRemainSp(string SroNum,
		                                    int? SroLine,
		                                    ref decimal? WipRemainMatl,
		                                    ref decimal? WipRemainLbr,
		                                    ref decimal? WipRemainFov,
		                                    ref decimal? WipRemainVov,
		                                    ref decimal? WipRemainOut,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROTransWipRemainExt = new SSSFSSROTransWipRemainFactory().Create(appDb);
				
				int Severity = iSSSFSSROTransWipRemainExt.SSSFSSROTransWipRemainSp(SroNum,
				                                                                   SroLine,
				                                                                   ref WipRemainMatl,
				                                                                   ref WipRemainLbr,
				                                                                   ref WipRemainFov,
				                                                                   ref WipRemainVov,
				                                                                   ref WipRemainOut,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransCheckPartnerSp(string PartnerId,
		string Table,
		string SroNum,
		int? SroLine,
		int? SroOper,
		ref string Dept,
		ref string Whse,
		ref byte? PartnerReimbMatl,
		ref byte? PartnerReimbLabor,
		ref string PartnerCurrCode,
		ref string VatLabel,
		ref string Infobar,
		[Optional] ref string WorkCode,
		[Optional] ref string MiscCode,
		[Optional] ref string ReimbTaxCode1,
		[Optional] ref string ReimbTaxCode2,
		[Optional] ref string ReimbMethod,
		[Optional] ref string WorkCodeDesc,
		[Optional] ref string MiscCodeDesc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROTransCheckPartnerExt = new SSSFSSROTransCheckPartnerFactory().Create(appDb);
				
				var result = iSSSFSSROTransCheckPartnerExt.SSSFSSROTransCheckPartnerSp(PartnerId,
				Table,
				SroNum,
				SroLine,
				SroOper,
				Dept,
				Whse,
				PartnerReimbMatl,
				PartnerReimbLabor,
				PartnerCurrCode,
				VatLabel,
				Infobar,
				WorkCode,
				MiscCode,
				ReimbTaxCode1,
				ReimbTaxCode2,
				ReimbMethod,
				WorkCodeDesc,
				MiscCodeDesc);
				
				int Severity = result.ReturnCode.Value;
				Dept = result.Dept;
				Whse = result.Whse;
				PartnerReimbMatl = result.PartnerReimbMatl;
				PartnerReimbLabor = result.PartnerReimbLabor;
				PartnerCurrCode = result.PartnerCurrCode;
				VatLabel = result.VatLabel;
				Infobar = result.Infobar;
				WorkCode = result.WorkCode;
				MiscCode = result.MiscCode;
				ReimbTaxCode1 = result.ReimbTaxCode1;
				ReimbTaxCode2 = result.ReimbTaxCode2;
				ReimbMethod = result.ReimbMethod;
				WorkCodeDesc = result.WorkCodeDesc;
				MiscCodeDesc = result.MiscCodeDesc;
				return Severity;
			}
		}





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetBillCodeSp(string Table,
		string ISroNum,
		int? ISroLine,
		int? ISroOper,
		DateTime? TransDate,
		DateTime? LineExchDate,
		ref string OBillCode,
		ref string Prompt,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSGetBillCodeExt = new SSSFSGetBillCodeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSGetBillCodeExt.SSSFSGetBillCodeSp(Table,
				ISroNum,
				ISroLine,
				ISroOper,
				TransDate,
				LineExchDate,
				OBillCode,
				Prompt,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OBillCode = result.OBillCode;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetPostDateSp(ref DateTime? TransDate,
		ref DateTime? PostDate,
		int? Error,
		ref string Prompt,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSGetPostDateExt = new SSSFSGetPostDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSGetPostDateExt.SSSFSGetPostDateSp(TransDate,
				PostDate,
				Error,
				Prompt,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TransDate = result.TransDate;
				PostDate = result.PostDate;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransValDefItemSp(string Table,
		string SRONum,
		int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		ref string Whse,
		string BillCode,
		string TransType,
		ref string Item,
		decimal? QtyConv,
		string PriceCurrCode,
		string Pricecode,
		int? ReimbMatl,
		ref string ItemDesc,
		ref string ItemUM,
		ref int? RtnToStock,
		ref decimal? UnitCostConv,
		ref decimal? UnitPriceConv,
		ref string Lot,
		ref string Loc,
		ref decimal? ConvFactor,
		ref int? SerialTracked,
		ref int? LotTracked,
		ref decimal? MatlCostConv,
		ref decimal? LaborCostConv,
		ref decimal? FovhdCostConv,
		ref decimal? VovhdCostConv,
		ref decimal? OutCostConv,
		ref decimal? Disc,
		ref string Prompt,
		ref string PromptButtons,
		ref string Infobar,
		[Optional] ref string RefType,
		[Optional, DefaultParameterValue("A")] string Type,
		[Optional] ref string TaxCode1,
		[Optional] ref string TaxCode2,
		[Optional] ref int? ItemExists,
		[Optional] ref string CustItem,
		[Optional] ref string SROCustNum,
		[Optional] ref string CostType,
		[Optional] ref string LotPrefix,
		[Optional] ref string SerialPrefix,
		[Optional, DefaultParameterValue(1)] int? ValidteItemExistsFlag,
		[Optional] ref string TrxRestrictCode,
		[Optional] ref string Revision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROTransValDefItemExt = new SSSFSSROTransValDefItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROTransValDefItemExt.SSSFSSROTransValDefItemSp(Table,
				SRONum,
				SROLine,
				SROOper,
				TransDate,
				Whse,
				BillCode,
				TransType,
				Item,
				QtyConv,
				PriceCurrCode,
				Pricecode,
				ReimbMatl,
				ItemDesc,
				ItemUM,
				RtnToStock,
				UnitCostConv,
				UnitPriceConv,
				Lot,
				Loc,
				ConvFactor,
				SerialTracked,
				LotTracked,
				MatlCostConv,
				LaborCostConv,
				FovhdCostConv,
				VovhdCostConv,
				OutCostConv,
				Disc,
				Prompt,
				PromptButtons,
				Infobar,
				RefType,
				Type,
				TaxCode1,
				TaxCode2,
				ItemExists,
				CustItem,
				SROCustNum,
				CostType,
				LotPrefix,
				SerialPrefix,
				ValidteItemExistsFlag,
				TrxRestrictCode,
				Revision);
				
				int Severity = result.ReturnCode.Value;
				Whse = result.Whse;
				Item = result.Item;
				ItemDesc = result.ItemDesc;
				ItemUM = result.ItemUM;
				RtnToStock = result.RtnToStock;
				UnitCostConv = result.UnitCostConv;
				UnitPriceConv = result.UnitPriceConv;
				Lot = result.Lot;
				Loc = result.Loc;
				ConvFactor = result.ConvFactor;
				SerialTracked = result.SerialTracked;
				LotTracked = result.LotTracked;
				MatlCostConv = result.MatlCostConv;
				LaborCostConv = result.LaborCostConv;
				FovhdCostConv = result.FovhdCostConv;
				VovhdCostConv = result.VovhdCostConv;
				OutCostConv = result.OutCostConv;
				Disc = result.Disc;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				RefType = result.RefType;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				ItemExists = result.ItemExists;
				CustItem = result.CustItem;
				SROCustNum = result.SROCustNum;
				CostType = result.CostType;
				LotPrefix = result.LotPrefix;
				SerialPrefix = result.SerialPrefix;
				TrxRestrictCode = result.TrxRestrictCode;
				Revision = result.Revision;
				return Severity;
			}
		}
    }
}
