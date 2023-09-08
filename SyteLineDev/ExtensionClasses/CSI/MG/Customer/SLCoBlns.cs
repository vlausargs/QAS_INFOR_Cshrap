//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoBlns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Data.RecordSets;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.ExternalContracts.RhythmIntegration;
using CSI.Logistics.Vendor;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLCoBlns")]
    public class SLCoBlns : CSIExtensionClassBase, IExtFTSLCoBlns, ISLCoBlns
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int BlanketLineItemValidSp(string CoNum,
                                          string Item,
                                          string CustNum,
                                          ref string ShipSite,
                                          string CurrCode,
                                          ref string ItemUM,
                                          ref string ItemDesc,
                                          ref string CustItem,
                                          ref string FeatStr,
                                          ref byte? ItemPlanFlag,
                                          ref string ItemFeatTempl,
                                          ref string ItemItem,
                                          ref byte? Kit,
                                          ref byte? PrintKitComponents,
                                          ref byte? ItemSerialTracked,
                                          ref byte? AllowOnPickList,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iBlanketLineItemValidExt = new BlanketLineItemValidFactory().Create(appDb);

                SiteType oShipSite = ShipSite;
                UMType oItemUM = ItemUM;
                DescriptionType oItemDesc = ItemDesc;
                CustItemType oCustItem = CustItem;
                FeatStrType oFeatStr = FeatStr;
                Flag oItemPlanFlag = ItemPlanFlag;
                FeatTemplateType oItemFeatTempl = ItemFeatTempl;
                ItemType oItemItem = ItemItem;
                ListYesNoType oKit = Kit;
                ListYesNoType oPrintKitComponents = PrintKitComponents;
                ListYesNoType oItemSerialTracked = ItemSerialTracked;
                ListYesNoType oAllowOnPickList = AllowOnPickList;
                Infobar oInfobar = Infobar;

                int Severity = iBlanketLineItemValidExt.BlanketLineItemValidSp(CoNum,
                                                                               Item,
                                                                               CustNum,
                                                                               ref oShipSite,
                                                                               CurrCode,
                                                                               ref oItemUM,
                                                                               ref oItemDesc,
                                                                               ref oCustItem,
                                                                               ref oFeatStr,
                                                                               ref oItemPlanFlag,
                                                                               ref oItemFeatTempl,
                                                                               ref oItemItem,
                                                                               ref oKit,
                                                                               ref oPrintKitComponents,
                                                                               ref oItemSerialTracked,
                                                                               ref oAllowOnPickList,
                                                                               ref oInfobar);

                ShipSite = oShipSite;
                ItemUM = oItemUM;
                ItemDesc = oItemDesc;
                CustItem = oCustItem;
                FeatStr = oFeatStr;
                ItemPlanFlag = oItemPlanFlag;
                ItemFeatTempl = oItemFeatTempl;
                ItemItem = oItemItem;
                Kit = oKit;
                PrintKitComponents = oPrintKitComponents;
                ItemSerialTracked = oItemSerialTracked;
                AllowOnPickList = oAllowOnPickList;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int BlanketLineOrderValidSp(ref string CoNum,
                                           ref string CustNum,
                                           ref byte? CadrCreditHold,
                                           ref DateTime? CoOrderDate,
                                           ref string CadrCurrCode,
                                           ref string CadrName,
                                           ref string CoPriceCode,
                                           ref string CoStat,
                                           ref DateTime? CoEffDate,
                                           ref DateTime? CoExpDate,
                                           ref string CoOrigSite,
                                           ref string Infobar,
                                           ref string CurrCstPrcFormat)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iBlanketLineOrderValidExt = new BlanketLineOrderValidFactory().Create(appDb);

                CoNumType oCoNum = CoNum;
                CustNumType oCustNum = CustNum;
                Flag oCadrCreditHold = CadrCreditHold;
                GenericDate oCoOrderDate = CoOrderDate;
                CurrCodeType oCadrCurrCode = CadrCurrCode;
                NameType oCadrName = CadrName;
                PriceCodeType oCoPriceCode = CoPriceCode;
                CoStatusType oCoStat = CoStat;
                GenericDate oCoEffDate = CoEffDate;
                GenericDate oCoExpDate = CoExpDate;
                SiteType oCoOrigSite = CoOrigSite;
                Infobar oInfobar = Infobar;
                InputMaskType oCurrCstPrcFormat = CurrCstPrcFormat;

                int Severity = iBlanketLineOrderValidExt.BlanketLineOrderValidSp(ref oCoNum,
                                                                                 ref oCustNum,
                                                                                 ref oCadrCreditHold,
                                                                                 ref oCoOrderDate,
                                                                                 ref oCadrCurrCode,
                                                                                 ref oCadrName,
                                                                                 ref oCoPriceCode,
                                                                                 ref oCoStat,
                                                                                 ref oCoEffDate,
                                                                                 ref oCoExpDate,
                                                                                 ref oCoOrigSite,
                                                                                 ref oInfobar,
                                                                                 ref oCurrCstPrcFormat);

                CoNum = oCoNum;
                CustNum = oCustNum;
                CadrCreditHold = oCadrCreditHold;
                CoOrderDate = oCoOrderDate;
                CadrCurrCode = oCadrCurrCode;
                CadrName = oCadrName;
                CoPriceCode = oCoPriceCode;
                CoStat = oCoStat;
                CoEffDate = oCoEffDate;
                CoExpDate = oCoExpDate;
                CoOrigSite = oCoOrigSite;
                Infobar = oInfobar;
                CurrCstPrcFormat = oCurrCstPrcFormat;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateItemCustSp(string CustNum,
			 string CustItem,
			 string Item,
			 ref string NewItem,
			 ref int? ItemCustExists,
			 ref int? ItemCustUpdate,
			 ref int? ItemCustAdd,
			 ref string WarningMsg,
			 ref string PromptMsg,
			 ref string PromptButtons,
			 ref string Infobar)
        {
            var iValidateItemCustExt = new ValidateItemCustFactory().Create(this, true);

            var result = iValidateItemCustExt.ValidateItemCustSp(CustNum,
				CustItem,
				Item,
				NewItem,
				ItemCustExists,
				ItemCustUpdate,
				ItemCustAdd,
				WarningMsg,
				PromptMsg,
				PromptButtons,
				Infobar);

            NewItem = result.NewItem;
            ItemCustExists = result.ItemCustExists;
            ItemCustUpdate = result.ItemCustUpdate;
            ItemCustAdd = result.ItemCustAdd;
            WarningMsg = result.WarningMsg;
            PromptMsg = result.PromptMsg;
            PromptButtons = result.PromptButtons;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_CalculateCoLineReleasePriceSp(string CoNum,
		                                            string CustNum,
		                                            string Item,
		                                            ref string ItemUM,
		                                            string CustItem,
		                                            string ShipSite,
		                                            DateTime? OrderDate,
		                                            DateTime? DueDate,
		                                            decimal? InQtyConv,
		                                            string CurrCode,
		                                            string ItemPriceCode,
		                                            ref decimal? PriceConv,
		                                            ref string Infobar,
		                                            short? CoLine,
		                                            [Optional, DefaultParameterValue((byte)0)] ref byte? DispMsg,
		[Optional] string ItemWhse,
		[Optional, DefaultParameterValue(0)] ref decimal? LineDisc,
		[Optional, DefaultParameterValue((byte)0)] ref byte? TaxInPriceDiff,
		[Optional] string PromotionCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_CalculateCoLineReleasePriceExt = new AU_CalculateCoLineReleasePriceFactory().Create(appDb);
				
				var result = iAU_CalculateCoLineReleasePriceExt.AU_CalculateCoLineReleasePriceSp(CoNum,
				                                                                                 CustNum,
				                                                                                 Item,
				                                                                                 ItemUM,
				                                                                                 CustItem,
				                                                                                 ShipSite,
				                                                                                 OrderDate,
				                                                                                 DueDate,
				                                                                                 InQtyConv,
				                                                                                 CurrCode,
				                                                                                 ItemPriceCode,
				                                                                                 PriceConv,
				                                                                                 Infobar,
				                                                                                 CoLine,
				                                                                                 DispMsg,
				                                                                                 ItemWhse,
				                                                                                 LineDisc,
				                                                                                 TaxInPriceDiff,
				                                                                                 PromotionCode);
				
				int Severity = result.ReturnCode.Value;
				ItemUM = result.ItemUM;
				PriceConv = result.PriceConv;
				Infobar = result.Infobar;
				DispMsg = result.DispMsg;
				LineDisc = result.LineDisc;
				TaxInPriceDiff = result.TaxInPriceDiff;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CoBlanketQtyValidSp(string CoNum,
		                               short? CoLine,
		                               string Item,
		                               decimal? BlanketQtyConv,
		                               ref string Infobar,
		                               [Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCoBlanketQtyValidExt = new CoBlanketQtyValidFactory().Create(appDb);
				
				var result = iCoBlanketQtyValidExt.CoBlanketQtyValidSp(CoNum,
				                                                       CoLine,
				                                                       Item,
				                                                       BlanketQtyConv,
				                                                       Infobar,
				                                                       Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CoBlnSetGloVarSp([Optional, DefaultParameterValue((byte)0)] byte? ItemCustAdd,
		[Optional, DefaultParameterValue((byte)0)] byte? ItemCustUpdate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCoBlnSetGloVarExt = new CoBlnSetGloVarFactory().Create(appDb);
				
				var result = iCoBlnSetGloVarExt.CoBlnSetGloVarSp(ItemCustAdd,
				                                                 ItemCustUpdate);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalculateCoitemPriceSp(string CoNum,
		string CustNum,
		string Item,
		ref string ItemUM,
		string CustItem,
		string ShipSite,
		DateTime? OrderDate,
		decimal? InQtyConv,
		string CurrCode,
		string ItemPriceCode,
		ref decimal? PriceConv,
		ref string Infobar,
		int? CoLine,
		[Optional, DefaultParameterValue(0)] ref int? DispMsg,
		[Optional] string ItemWhse,
		[Optional, DefaultParameterValue(0)] ref decimal? LineDisc,
		[Optional, DefaultParameterValue(0)] ref int? TaxInPriceDiff,
		[Optional] string PromotionCode,
		[Optional] string AUContractPriceMethod,
		[Optional] string ConTractID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalculateCoitemPriceExt = new CalculateCoitemPriceFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalculateCoitemPriceExt.CalculateCoitemPriceSp(CoNum,
				CustNum,
				Item,
				ItemUM,
				CustItem,
				ShipSite,
				OrderDate,
				InQtyConv,
				CurrCode,
				ItemPriceCode,
				PriceConv,
				Infobar,
				CoLine,
				DispMsg,
				ItemWhse,
				LineDisc,
				TaxInPriceDiff,
				PromotionCode,
				AUContractPriceMethod,
				ConTractID);
				
				int Severity = result.ReturnCode.Value;
				ItemUM = result.ItemUM;
				PriceConv = result.PriceConv;
				Infobar = result.Infobar;
				DispMsg = result.DispMsg;
				LineDisc = result.LineDisc;
				TaxInPriceDiff = result.TaxInPriceDiff;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CoBlnCfSansSp(string PCoNum,
		int? PCoLine,
		string PStatus,
		ref int? PAnyFound)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCoBlnCfSansExt = new CoBlnCfSansFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCoBlnCfSansExt.CoBlnCfSansSp(PCoNum,
				PCoLine,
				PStatus,
				PAnyFound);
				
				int Severity = result.ReturnCode.Value;
				PAnyFound = result.PAnyFound;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CoBlnPostQuerySp(string CoNum,
		int? CoLine,
		ref decimal? QtyReserved,
		ref decimal? QtyShipped,
		ref decimal? QtyReleased,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCoBlnPostQueryExt = new CoBlnPostQueryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCoBlnPostQueryExt.CoBlnPostQuerySp(CoNum,
				CoLine,
				QtyReserved,
				QtyShipped,
				QtyReleased,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				QtyReserved = result.QtyReserved;
				QtyShipped = result.QtyShipped;
				QtyReleased = result.QtyReleased;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetCoitemLinePriceNoCONumSp(string PCustomerNum,
		string CoitemItem,
		string PAtlItemUM,
		string PShipSite,
		DateTime? POrderDate,
		ref decimal? CoitemDisc,
		decimal? CoitemQtyOrdered,
		string CustCurCode,
		string ItemPriceCode,
		ref decimal? CoitemLinePrice,
		ref string Infobar,
		[Optional] ref decimal? LineTaxAmount,
		[Optional] ref decimal? CoitemPrice,
		[Optional] ref int? CurrencyPlaces,
		[Optional] Guid? CoitemRowPointer,
		[Optional] ref string TaxAmountLabel,
		[Optional] ref string SiteLanguageID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetCoitemLinePriceNoCONumExt = new GetCoitemLinePriceNoCONumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetCoitemLinePriceNoCONumExt.GetCoitemLinePriceNoCONumSp(PCustomerNum,
				CoitemItem,
				PAtlItemUM,
				PShipSite,
				POrderDate,
				CoitemDisc,
				CoitemQtyOrdered,
				CustCurCode,
				ItemPriceCode,
				CoitemLinePrice,
				Infobar,
				LineTaxAmount,
				CoitemPrice,
				CurrencyPlaces,
				CoitemRowPointer,
				TaxAmountLabel,
				SiteLanguageID);
				
				int Severity = result.ReturnCode.Value;
				CoitemDisc = result.CoitemDisc;
				CoitemLinePrice = result.CoitemLinePrice;
				Infobar = result.Infobar;
				LineTaxAmount = result.LineTaxAmount;
				CoitemPrice = result.CoitemPrice;
				CurrencyPlaces = result.CurrencyPlaces;
				TaxAmountLabel = result.TaxAmountLabel;
				SiteLanguageID = result.SiteLanguageID;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_RepriceCoitemorBlanketLinesSp(int? LineorBlanketLine,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		decimal? NewPrice,
		DateTime? RecordDate,
		[Optional] Guid? SessionID,
		[Optional] string ReasonText,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAU_RepriceCoitemorBlanketLinesExt = new AU_RepriceCoitemorBlanketLinesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAU_RepriceCoitemorBlanketLinesExt.AU_RepriceCoitemorBlanketLinesSp(LineorBlanketLine,
				CoNum,
				CoLine,
				CoRelease,
				NewPrice,
				RecordDate,
				SessionID,
				ReasonText,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CfgRemoveConfigurationHoldSp(string SourceRefType,
		string RefNum,
		int? RefLineSuf,
		int? ConfigHold)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCfgRemoveConfigurationHoldExt = new CfgRemoveConfigurationHoldFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCfgRemoveConfigurationHoldExt.CfgRemoveConfigurationHoldSp(SourceRefType,
				RefNum,
				RefLineSuf,
				ConfigHold);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CSI.Logistics.Customer.CLM_DomesticCurrencyFactory().Create(this, true);
			
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDIFOTPolicySp([Optional] string Site,
		[Optional] string PCoNum,
		[Optional] int? PCoLine,
		[Optional] int? PCoRelease,
		[Optional] string PCustNum,
		[Optional] int? PCustSeq,
		int? PHierarchy,
		ref decimal? shipped_over_ordered_qty_tolerance,
		ref decimal? shipped_under_ordered_qty_tolerance,
		ref int? days_shipped_after_due_date_tolerance,
		ref int? days_shipped_before_due_date_tolerance)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetDIFOTPolicyExt = new GetDIFOTPolicyFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetDIFOTPolicyExt.GetDIFOTPolicySp(Site,
				PCoNum,
				PCoLine,
				PCoRelease,
				PCustNum,
				PCustSeq,
				PHierarchy,
				shipped_over_ordered_qty_tolerance,
				shipped_under_ordered_qty_tolerance,
				days_shipped_after_due_date_tolerance,
				days_shipped_before_due_date_tolerance);
				
				int Severity = result.ReturnCode.Value;
				shipped_over_ordered_qty_tolerance = result.shipped_over_ordered_qty_tolerance;
				shipped_under_ordered_qty_tolerance = result.shipped_under_ordered_qty_tolerance;
				days_shipped_after_due_date_tolerance = result.days_shipped_after_due_date_tolerance;
				days_shipped_before_due_date_tolerance = result.days_shipped_before_due_date_tolerance;
				return Severity;
			}
		}
    }
}
