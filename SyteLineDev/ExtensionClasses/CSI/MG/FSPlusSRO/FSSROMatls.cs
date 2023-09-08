//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROMatls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSSROMatls")]
    public class FSSROMatls : CSIExtensionClassBase, IExtFTFSSROMatls, IFSSROMatls
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSXrefPreCreateTSp(string iItem,
                                         string iToWhse,
                                         ref string oFromSite,
                                         ref string oFromWhse,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSXrefPreCreateTExt = new SSSFSXrefPreCreateTFactory().Create(appDb);

                int Severity = iSSSFSXrefPreCreateTExt.SSSFSXrefPreCreateTSp(iItem,
                                                                             iToWhse,
                                                                             ref oFromSite,
                                                                             ref oFromWhse,
                                                                             ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransGetItemDefSp(string MatlItem,
			ref string Origin,
			ref string CommCode,
			ref decimal? UnitWeight)
		{
			var iSSSFSSROTransGetItemDefExt = new SSSFSSROTransGetItemDefFactory().Create(this, true);
			
			var result = iSSSFSSROTransGetItemDefExt.SSSFSSROTransGetItemDefSp(MatlItem,
				Origin,
				CommCode,
				UnitWeight);
			
			Origin = result.Origin;
			CommCode = result.CommCode;
			UnitWeight = result.UnitWeight;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroTransXrefMatlTSp(string PTrnNum,
		                                    short? PTrnLine,
		                                    ref int? XrefTrn,
		                                    ref string RefDescription,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroTransXrefMatlTExt = new SSSFSSroTransXrefMatlTFactory().Create(appDb);
				
				int Severity = iSSSFSSroTransXrefMatlTExt.SSSFSSroTransXrefMatlTSp(PTrnNum,
				                                                                   PTrnLine,
				                                                                   ref XrefTrn,
				                                                                   ref RefDescription,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalValidateSROMatlSp(string SroNum,
		                                        int? SroLine,
		                                        int? SroOper,
		                                        string PartnerID,
		                                        DateTime? TransDate,
		                                        string CustNum,
		                                        string CustSeq,
		                                        string Username,
		                                        string Item,
		                                        string UM,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalValidateSROMatlExt = new SSSFSPortalValidateSROMatlFactory().Create(appDb);
				
				int Severity = iSSSFSPortalValidateSROMatlExt.SSSFSPortalValidateSROMatlSp(SroNum,
				                                                                           SroLine,
				                                                                           SroOper,
				                                                                           PartnerID,
				                                                                           TransDate,
				                                                                           CustNum,
				                                                                           CustSeq,
				                                                                           Username,
				                                                                           Item,
				                                                                           UM,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROMatlDCValidSp(string Level,
                                         string PartnerID,
                                         DateTime? TransDate,
                                         string SRONum,
                                         ref int? SROLine,
                                         ref int? SROOper,
                                         ref string SroDesc,
                                         ref string LineItem,
                                         ref string OperDesc,
                                         ref string TransType,
                                         ref string BillCode,
                                         ref string Whse,
                                         ref string Infobar,
                                         ref string CustNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROMatlDCValidExt = new SSSFSSROMatlDCValidFactory().Create(appDb);

                int Severity = iSSSFSSROMatlDCValidExt.SSSFSSROMatlDCValidSp(Level,
                                                                             PartnerID,
                                                                             TransDate,
                                                                             SRONum,
                                                                             ref SROLine,
                                                                             ref SROOper,
                                                                             ref SroDesc,
                                                                             ref LineItem,
                                                                             ref OperDesc,
                                                                             ref TransType,
                                                                             ref BillCode,
                                                                             ref Whse,
                                                                             ref Infobar,
                                                                             ref CustNum);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConsoleTransSaveSp(Guid? RowPointer,
		                                   string TransType,
		                                   string RefType,
		                                   string RefNum,
		                                   int? RefLineSuf,
		                                   int? RefRelease)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSConsoleTransSaveExt = new SSSFSConsoleTransSaveFactory().Create(appDb);
				
				int Severity = iSSSFSConsoleTransSaveExt.SSSFSConsoleTransSaveSp(RowPointer,
				                                                                 TransType,
				                                                                 RefType,
				                                                                 RefNum,
				                                                                 RefLineSuf,
				                                                                 RefRelease);
				
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
		public int SSSFSSROTransGetEcCodeSp(string SroNum,
		                                    string DropType,
		                                    string DropNum,
		                                    int? DropSeq,
		                                    ref string EcCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROTransGetEcCodeExt = new SSSFSSROTransGetEcCodeFactory().Create(appDb);
				
				int Severity = iSSSFSSROTransGetEcCodeExt.SSSFSSROTransGetEcCodeSp(SroNum,
				                                                                   DropType,
				                                                                   DropNum,
				                                                                   DropSeq,
				                                                                   ref EcCode);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroTransPostMatlSp(Guid? iRowPointer,
		                                   byte? iLineTrans,
		                                   string iMode,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroTransPostMatlExt = new SSSFSSroTransPostMatlFactory().Create(appDb);
				
				int Severity = iSSSFSSroTransPostMatlExt.SSSFSSroTransPostMatlSp(iRowPointer,
				                                                                 iLineTrans,
				                                                                 iMode,
				                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroTransSetItemCostsSp(string SRONum,
		                                       int? SROLine,
		                                       int? SROOper,
		                                       string Item,
		                                       string UM,
		                                       string Whse,
		                                       byte? ReimbMatl,
		                                       byte? RtnToStock,
		                                       string TransType,
		                                       string Type,
		                                       ref decimal? UnitCostConv,
		                                       ref decimal? MatlCostConv,
		                                       ref decimal? LaborCostConv,
		                                       ref decimal? FovhdCostConv,
		                                       ref decimal? VovhdCostConv,
		                                       ref decimal? OutCostConv,
		                                       ref string Infobar,
		                                       decimal? QtyConv,
		                                       string Loc,
		                                       string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroTransSetItemCostsExt = new SSSFSSroTransSetItemCostsFactory().Create(appDb);
				
				int Severity = iSSSFSSroTransSetItemCostsExt.SSSFSSroTransSetItemCostsSp(SRONum,
				                                                                         SROLine,
				                                                                         SROOper,
				                                                                         Item,
				                                                                         UM,
				                                                                         Whse,
				                                                                         ReimbMatl,
				                                                                         RtnToStock,
				                                                                         TransType,
				                                                                         Type,
				                                                                         ref UnitCostConv,
				                                                                         ref MatlCostConv,
				                                                                         ref LaborCostConv,
				                                                                         ref FovhdCostConv,
				                                                                         ref VovhdCostConv,
				                                                                         ref OutCostConv,
				                                                                         ref Infobar,
				                                                                         QtyConv,
				                                                                         Loc,
				                                                                         Lot);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSInspSignOffSp(string Type,
		                              Guid? RowPointer,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSInspSignOffExt = new SSSFSInspSignOffFactory().Create(appDb);
				
				int Severity = iSSSFSInspSignOffExt.SSSFSInspSignOffSp(Type,
				                                                       RowPointer,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalCreateSROMatlSp(string SroNum,
		                                      int? SroLine,
		                                      int? SroOper,
		                                      string PartnerID,
		                                      DateTime? TransDate,
		                                      string CustNum,
		                                      string CustSeq,
		                                      string Username,
		                                      string Item,
		                                      string MatlDescription,
		                                      string UM,
		                                      decimal? QtyConv,
		                                      string NoteContent,
		                                      [Optional, DefaultParameterValue((byte)0)] byte? Validate,
		ref Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalCreateSROMatlExt = new SSSFSPortalCreateSROMatlFactory().Create(appDb);
				
				var result = iSSSFSPortalCreateSROMatlExt.SSSFSPortalCreateSROMatlSp(SroNum,
				                                                                     SroLine,
				                                                                     SroOper,
				                                                                     PartnerID,
				                                                                     TransDate,
				                                                                     CustNum,
				                                                                     CustSeq,
				                                                                     Username,
				                                                                     Item,
				                                                                     MatlDescription,
				                                                                     UM,
				                                                                     QtyConv,
				                                                                     NoteContent,
				                                                                     Validate,
				                                                                     RowPointer,
				                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROMatlDCItemSp(string PartnerId,
		                                string SroNum,
		                                int? SroLine,
		                                int? SroOper,
		                                DateTime? TransDate,
		                                string Item,
		                                string Whse,
		                                decimal? QtyConv,
		                                string BillCode,
		                                string TransType,
		                                ref string Description,
		                                ref string UM,
		                                ref string Loc,
		                                ref string Lot,
		                                ref byte? LotTracked,
		                                ref byte? SerialTracked,
		                                ref decimal? UnitCostConv,
		                                ref decimal? UnitPriceConv,
		                                ref string CurrCode,
		                                ref string CustNum,
		                                ref string Pricecode,
		                                ref string Infobar,
		                                ref string CustItem,
		                                ref string LotPrefix,
		                                [Optional] ref string Prompt,
		                                [Optional] ref string PromptButtons,
		                                [Optional, DefaultParameterValue((byte)1)] byte? ValidteItemExistsFlag)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROMatlDCItemExt = new SSSFSSROMatlDCItemFactory().Create(appDb);
				
				var result = iSSSFSSROMatlDCItemExt.SSSFSSROMatlDCItemSp(PartnerId,
				                                                         SroNum,
				                                                         SroLine,
				                                                         SroOper,
				                                                         TransDate,
				                                                         Item,
				                                                         Whse,
				                                                         QtyConv,
				                                                         BillCode,
				                                                         TransType,
				                                                         Description,
				                                                         UM,
				                                                         Loc,
				                                                         Lot,
				                                                         LotTracked,
				                                                         SerialTracked,
				                                                         UnitCostConv,
				                                                         UnitPriceConv,
				                                                         CurrCode,
				                                                         CustNum,
				                                                         Pricecode,
				                                                         Infobar,
				                                                         CustItem,
				                                                         LotPrefix,
				                                                         Prompt,
				                                                         PromptButtons,
				                                                         ValidteItemExistsFlag);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				UM = result.UM;
				Loc = result.Loc;
				Lot = result.Lot;
				LotTracked = result.LotTracked;
				SerialTracked = result.SerialTracked;
				UnitCostConv = result.UnitCostConv;
				UnitPriceConv = result.UnitPriceConv;
				CurrCode = result.CurrCode;
				CustNum = result.CustNum;
				Pricecode = result.Pricecode;
				Infobar = result.Infobar;
				CustItem = result.CustItem;
				LotPrefix = result.LotPrefix;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROMatlDCSaveSp(string PartnerId,
		                                string SroNum,
		                                int? SroLine,
		                                int? SroOper,
		                                string Item,
		                                string TransType,
		                                DateTime? TransDate,
		                                decimal? QtyConv,
		                                string UM,
		                                string Whse,
		                                string Loc,
		                                string Lot,
		                                decimal? PriceConv,
		                                string BillCode,
		                                string NoteContent,
		                                ref Guid? RowPointer,
		                                ref int? TransNum,
		                                ref byte? AutoPost,
		                                ref string Infobar,
		                                string CustItem,
		                                [Optional] ref string Prompt,
		                                [Optional] ref string PromptButtons,
		                                [Optional] string MatlDescription,
		                                [Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROMatlDCSaveExt = new SSSFSSROMatlDCSaveFactory().Create(appDb);
				
				var result = iSSSFSSROMatlDCSaveExt.SSSFSSROMatlDCSaveSp(PartnerId,
				                                                         SroNum,
				                                                         SroLine,
				                                                         SroOper,
				                                                         Item,
				                                                         TransType,
				                                                         TransDate,
				                                                         QtyConv,
				                                                         UM,
				                                                         Whse,
				                                                         Loc,
				                                                         Lot,
				                                                         PriceConv,
				                                                         BillCode,
				                                                         NoteContent,
				                                                         RowPointer,
				                                                         TransNum,
				                                                         AutoPost,
				                                                         Infobar,
				                                                         CustItem,
				                                                         Prompt,
				                                                         PromptButtons,
				                                                         MatlDescription,
				                                                         DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				TransNum = result.TransNum;
				AutoPost = result.AutoPost;
				Infobar = result.Infobar;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROPackSlipLine_ShipOneSp(Guid? RowPointer,
		                                          string Mode,
		                                          decimal? QtyToShipConv,
		                                          string Loc,
		                                          string Lot,
		                                          DateTime? TransDate,
		                                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROPackSlipLine_ShipOneExt = new SSSFSSROPackSlipLine_ShipOneFactory().Create(appDb);
				
				var result = iSSSFSSROPackSlipLine_ShipOneExt.SSSFSSROPackSlipLine_ShipOneSp(RowPointer,
				                                                                             Mode,
				                                                                             QtyToShipConv,
				                                                                             Loc,
				                                                                             Lot,
				                                                                             TransDate,
				                                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROMatlRateSp(string InType,
		                              string InSroNum,
		                              int? InSroLine,
		                              int? InSroOper,
		                              string InItem,
		                              string InCustNum,
		                              DateTime? InTransDate,
		                              decimal? InQty,
		                              string InCurrCode,
		                              string InPricecode,
		                              string InBillCode,
		                              decimal? InCost,
		                              ref decimal? OutUnitPrice,
		                              ref string Prompt,
		                              ref string PromptButtons,
		                              ref string Infobar,
		                              string UM,
		                              ref decimal? OutUnitPriceConv,
		                              [Optional] string InCustItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroMatlRateExt = new SSSFSSroMatlRateFactory().Create(appDb);
				
				var result = iSSSFSSroMatlRateExt.SSSFSSroMatlRateSp(InType,
				                                                     InSroNum,
				                                                     InSroLine,
				                                                     InSroOper,
				                                                     InItem,
				                                                     InCustNum,
				                                                     InTransDate,
				                                                     InQty,
				                                                     InCurrCode,
				                                                     InPricecode,
				                                                     InBillCode,
				                                                     InCost,
				                                                     OutUnitPrice,
				                                                     Prompt,
				                                                     PromptButtons,
				                                                     Infobar,
				                                                     UM,
				                                                     OutUnitPriceConv,
				                                                     InCustItem);
				
				int Severity = result.ReturnCode.Value;
				OutUnitPrice = result.OutUnitPrice;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				OutUnitPriceConv = result.OutUnitPriceConv;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSCustItemCreateSp(string Item,
		string CustNum,
		string CustItem,
		string UM,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSCustItemCreateExt = new SSSFSCustItemCreateFactory().Create(appDb);
				
				var result = iSSSFSCustItemCreateExt.SSSFSCustItemCreateSp(Item,
				CustNum,
				CustItem,
				UM,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
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
		public int SSSFSSROPackSlipLine_UpdSp([Optional, DefaultParameterValue((byte)0)] byte? DerSelected,
		Guid? RowPointer,
		[Optional] int? PackNum,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] Guid? DerHdrRowPointer,
		[Optional] string DocNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROPackSlipLine_UpdExt = new SSSFSSROPackSlipLine_UpdFactory().Create(appDb);
				
				var result = iSSSFSSROPackSlipLine_UpdExt.SSSFSSROPackSlipLine_UpdSp(DerSelected,
				RowPointer,
				PackNum,
				Whse,
				Loc,
				Lot,
				DerHdrRowPointer,
				DocNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransGenReimbTaxSp(Guid? RowPointer,
		string TransType,
		ref string InfoBar,
		[Optional] decimal? TaxAmount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROTransGenReimbTaxExt = new SSSFSSROTransGenReimbTaxFactory().Create(appDb);
				
				var result = iSSSFSSROTransGenReimbTaxExt.SSSFSSROTransGenReimbTaxSp(RowPointer,
				TransType,
				InfoBar,
				TaxAmount);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransWhseValidSp(string Item,
		ref string Whse,
		ref string Lot,
		ref string Loc,
		ref string Infobar,
		[Optional] ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROTransWhseValidExt = new SSSFSSROTransWhseValidFactory().Create(appDb);
				
				var result = iSSSFSSROTransWhseValidExt.SSSFSSROTransWhseValidSp(Item,
				Whse,
				Lot,
				Loc,
				Infobar,
				TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Whse = result.Whse;
				Lot = result.Lot;
				Loc = result.Loc;
				Infobar = result.Infobar;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSConsoleLoadTransSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string PlanAct,
		[Optional] string SiteRef,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSConsoleLoadTransExt = new SSSFSConsoleLoadTransFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSConsoleLoadTransExt.SSSFSConsoleLoadTransSp(SroNum,
				SroLine,
				SroOper,
				PlanAct,
				SiteRef,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
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
		public int SSSFSSRODefaultQtySp(string RefNum,
		int? RefLine,
		ref decimal? Qty)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSRODefaultQtyExt = new SSSFSSRODefaultQtyFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSRODefaultQtyExt.SSSFSSRODefaultQtySp(RefNum,
				RefLine,
				Qty);
				
				int Severity = result.ReturnCode.Value;
				Qty = result.Qty;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSROPackSlipLine_LoadSp([Optional] int? PackNum,
		[Optional] string SRONum,
		[Optional] int? SROLine,
		[Optional] int? SROOper,
		[Optional, DefaultParameterValue(0)] int? TransPosted,
		[Optional] string InWhse,
		[Optional, DefaultParameterValue(1)] int? AllShipTos,
		[Optional, DefaultParameterValue("N")] string ShipToType,
		[Optional] string ShipToNum,
		[Optional] int? ShipToSeq,
		[Optional, DefaultParameterValue(0)] int? AddMode,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROPackSlipLine_LoadExt = new SSSFSSROPackSlipLine_LoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROPackSlipLine_LoadExt.SSSFSSROPackSlipLine_LoadSp(PackNum,
				SRONum,
				SROLine,
				SROOper,
				TransPosted,
				InWhse,
				AllShipTos,
				ShipToType,
				ShipToNum,
				ShipToSeq,
				AddMode,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSROPackSlipLineCLMSp(int? PackNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROPackSlipLineCLMExt = new SSSFSSROPackSlipLineCLMFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROPackSlipLineCLMExt.SSSFSSROPackSlipLineCLMSp(PackNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroPlanTransPostMatlSp(Guid? iRowPointer,
		string iMode,
		string iPartnerId,
		string iDept,
		string iWhse,
		DateTime? iTransDate,
		DateTime? iPostDate,
		decimal? iPstMatlQtyConv,
		decimal? iMatlCostConv,
		decimal? iLbrCostConv,
		decimal? iFovhdCostConv,
		decimal? iVovhdCostConv,
		decimal? iOutCostConv,
		string UpdateStatus,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSroPlanTransPostMatlExt = new SSSFSSroPlanTransPostMatlFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSroPlanTransPostMatlExt.SSSFSSroPlanTransPostMatlSp(iRowPointer,
				iMode,
				iPartnerId,
				iDept,
				iWhse,
				iTransDate,
				iPostDate,
				iPstMatlQtyConv,
				iMatlCostConv,
				iLbrCostConv,
				iFovhdCostConv,
				iVovhdCostConv,
				iOutCostConv,
				UpdateStatus,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransCstPrcTaxSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string Item,
		string Whse,
		string Loc,
		string Lot,
		string BillCode,
		DateTime? TransDate,
		string Pricecode,
		decimal? Qty,
		string PartnerId,
		string UM,
		ref decimal? DefCost,
		ref decimal? DefPrice,
		ref decimal? Disc,
		ref string TaxCode1,
		ref string TaxCode2,
		ref string Infobar,
		[Optional] decimal? Cost,
		[Optional] string CustItem,
		[Optional] ref string RefType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROTransCstPrcTaxExt = new SSSFSSROTransCstPrcTaxFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROTransCstPrcTaxExt.SSSFSSROTransCstPrcTaxSp(SroNum,
				SroLine,
				SroOper,
				Item,
				Whse,
				Loc,
				Lot,
				BillCode,
				TransDate,
				Pricecode,
				Qty,
				PartnerId,
				UM,
				DefCost,
				DefPrice,
				Disc,
				TaxCode1,
				TaxCode2,
				Infobar,
				Cost,
				CustItem,
				RefType);
				
				int Severity = result.ReturnCode.Value;
				DefCost = result.DefCost;
				DefPrice = result.DefPrice;
				Disc = result.Disc;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				Infobar = result.Infobar;
				RefType = result.RefType;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransSetItemPriceSp(string CalledFrom,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string Item,
		DateTime? TransDate,
		decimal? QtyConv,
		string BillCode,
		decimal? CostConv,
		ref decimal? PriceConv,
		ref string Prompt,
		ref string PromptButtons,
		ref string Infobar,
		string UM,
		string CustItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROTransSetItemPriceExt = new SSSFSSROTransSetItemPriceFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROTransSetItemPriceExt.SSSFSSROTransSetItemPriceSp(CalledFrom,
				SroNum,
				SroLine,
				SroOper,
				Item,
				TransDate,
				QtyConv,
				BillCode,
				CostConv,
				PriceConv,
				Prompt,
				PromptButtons,
				Infobar,
				UM,
				CustItem);
				
				int Severity = result.ReturnCode.Value;
				PriceConv = result.PriceConv;
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransValidSROMatlSp(string Table,
		string Level,
		string SRONum,
		ref int? SROLine,
		ref int? SROOper,
		ref DateTime? TransDate,
		ref DateTime? PostDate,
		ref string PartnerID,
		ref int? PartnerReimbMatl,
		ref string Dept,
		ref string Whse,
		ref string BillCode,
		ref string TransType,
		ref int? RtnToStock,
		ref string Item,
		ref string ItemDesc,
		ref string ItemUM,
		ref string Unit,
		ref decimal? QtyConv,
		ref decimal? UnitCostConv,
		ref decimal? UnitPriceConv,
		ref string Lot,
		ref string Loc,
		ref string TaxCode1,
		ref string TaxCode2,
		ref string VatLabel,
		ref DateTime? ExchDate,
		ref string UsageType,
		ref int? SerialTracked,
		ref int? LotTracked,
		ref decimal? MatlCostConv,
		ref decimal? LaborCostConv,
		ref decimal? FovhdCostConv,
		ref decimal? VovhdCostConv,
		ref decimal? OutCostConv,
		ref decimal? Disc,
		ref string PriceCode,
		ref string PriceCurrCode,
		ref string Prompt,
		ref string PromptButtons,
		ref string Infobar,
		ref string CustItem,
		ref string SROCustNum,
		ref string CurAmtFormat,
		ref string CurCstPrcFormat,
		[Optional, DefaultParameterValue("A")] string Type,
		[Optional] ref string ReimbTaxCode1,
		[Optional] ref string ReimbTaxCode2,
		[Optional] ref string ReimbMethod,
		[Optional] ref int? ItemExists,
		[Optional] ref string TrxRestrictCode,
		[Optional] ref string Revision,
		[Optional, DefaultParameterValue(0)] ref int? TrackEcn)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROTransValidSROMatlExt = new SSSFSSROTransValidSROMatlFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROTransValidSROMatlExt.SSSFSSROTransValidSROMatlSp(Table,
				Level,
				SRONum,
				SROLine,
				SROOper,
				TransDate,
				PostDate,
				PartnerID,
				PartnerReimbMatl,
				Dept,
				Whse,
				BillCode,
				TransType,
				RtnToStock,
				Item,
				ItemDesc,
				ItemUM,
				Unit,
				QtyConv,
				UnitCostConv,
				UnitPriceConv,
				Lot,
				Loc,
				TaxCode1,
				TaxCode2,
				VatLabel,
				ExchDate,
				UsageType,
				SerialTracked,
				LotTracked,
				MatlCostConv,
				LaborCostConv,
				FovhdCostConv,
				VovhdCostConv,
				OutCostConv,
				Disc,
				PriceCode,
				PriceCurrCode,
				Prompt,
				PromptButtons,
				Infobar,
				CustItem,
				SROCustNum,
				CurAmtFormat,
				CurCstPrcFormat,
				Type,
				ReimbTaxCode1,
				ReimbTaxCode2,
				ReimbMethod,
				ItemExists,
				TrxRestrictCode,
				Revision,
				TrackEcn);
				
				int Severity = result.ReturnCode.Value;
				SROLine = result.SROLine;
				SROOper = result.SROOper;
				TransDate = result.TransDate;
				PostDate = result.PostDate;
				PartnerID = result.PartnerID;
				PartnerReimbMatl = result.PartnerReimbMatl;
				Dept = result.Dept;
				Whse = result.Whse;
				BillCode = result.BillCode;
				TransType = result.TransType;
				RtnToStock = result.RtnToStock;
				Item = result.Item;
				ItemDesc = result.ItemDesc;
				ItemUM = result.ItemUM;
				Unit = result.Unit;
				QtyConv = result.QtyConv;
				UnitCostConv = result.UnitCostConv;
				UnitPriceConv = result.UnitPriceConv;
				Lot = result.Lot;
				Loc = result.Loc;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				VatLabel = result.VatLabel;
				ExchDate = result.ExchDate;
				UsageType = result.UsageType;
				SerialTracked = result.SerialTracked;
				LotTracked = result.LotTracked;
				MatlCostConv = result.MatlCostConv;
				LaborCostConv = result.LaborCostConv;
				FovhdCostConv = result.FovhdCostConv;
				VovhdCostConv = result.VovhdCostConv;
				OutCostConv = result.OutCostConv;
				Disc = result.Disc;
				PriceCode = result.PriceCode;
				PriceCurrCode = result.PriceCurrCode;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				CustItem = result.CustItem;
				SROCustNum = result.SROCustNum;
				CurAmtFormat = result.CurAmtFormat;
				CurCstPrcFormat = result.CurCstPrcFormat;
				ReimbTaxCode1 = result.ReimbTaxCode1;
				ReimbTaxCode2 = result.ReimbTaxCode2;
				ReimbMethod = result.ReimbMethod;
				ItemExists = result.ItemExists;
				TrxRestrictCode = result.TrxRestrictCode;
				Revision = result.Revision;
				TrackEcn = result.TrackEcn;
				return Severity;
			}
		}
    }
}
